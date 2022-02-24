using CurrencyService.Models;
using CurrencyService.Services;
using System.Diagnostics;
using System.Text.Json;

namespace CurrencyService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private Stopwatch watch;
         
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            // the code that you want to measure comes here
            
            while (!stoppingToken.IsCancellationRequested)
            {
               
                try
                {
                    
                    await GetCurrencyFromApi();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error", ex.Message);
                }
                finally
                {
                    
                    watch.Stop();
                    _logger.LogInformation("Duration of work in Milliseconds: {time}", watch.ElapsedMilliseconds);
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }


        private async Task GetCurrencyFromApi()
        {
            watch = Stopwatch.StartNew();
            _logger.LogInformation("Worker running at: {time}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


            HttpClient httpClient = new();
            string baseUrl = _configuration["Logging:API:baseUrl"];
            string endpoint = _configuration["Logging:API:currencyEndpoint"];

            var response = await httpClient.GetAsync(baseUrl + endpoint);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var currency = JsonSerializer.Deserialize<CurrencyModel>(jsonString);
                    _logger.LogInformation("Currency found in Queue API: ::{currency}::", currency.Item.Moeda);
                    _logger.LogInformation("Process file DadosMoeda.csv {time}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    var dadosMoeda = FileService.DadosMoedaCsvRead(@".\DadosMoeda.csv");

                    if(dadosMoeda.Count > 0)
                    {
                        //buscar arquivo cotacao
                        _logger.LogInformation("Process file DadosCotacao.csv {time}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        var dadosCotacao = FileService.DadosCotacaoCsvRead(@".\DadosCotacao.csv");

                        var rangeCurrencies = dadosMoeda.Where(x =>
                            x.DataRef >= currency.Item.DataInicio &&
                            x.DataRef <= currency.Item.DataFim)
                            .ToList();

                        var result = new List<ResultModel>() ;

                        if(rangeCurrencies.Count > 0)
                        {
                           
                            for (int i = 0; i < rangeCurrencies.Count; i++)
                            {
                                var currencyId = CurrencyHelper.CurrencyDePara.Where(ch => ch.Cod.Equals(rangeCurrencies[i].IdMoeda)).FirstOrDefault();
                                var minDate = rangeCurrencies.Where(r => r.IdMoeda.Equals(currencyId.Cod)).Min(r => r.DataRef);
                                var maxDate = rangeCurrencies.Where(r => r.IdMoeda.Equals(currencyId.Cod)).Max(r => r.DataRef);

                                if (dadosCotacao.Count > 0)
                                {
                                    var prices = dadosCotacao.Where(x => 
                                        x.CodCotacao.Equals(currencyId.Id.ToString()) &&
                                        (x.DatCotacao >= minDate && x.DatCotacao <= maxDate)
                                        ).ToList();

                                    _logger.LogInformation("{qtd} ::prices:: found in the period: {dt1} {dt2}", rangeCurrencies.Count, currency.Item.DataInicio, currency.Item.DataFim);

                                    for (int j = 0; j < prices.Count; j++)
                                    {
                                        _logger.LogInformation("Result ->: {id} | {date} | {price}", rangeCurrencies[i].IdMoeda, rangeCurrencies[i].DataRef.ToString("yyyy-MM-dd"), prices[j].VlrCotacao);

                                        result.Add(new ResultModel
                                        {
                                            ID_MOEDA = currencyId.Cod,
                                            DATA_REF = rangeCurrencies[i].DataRef.ToString("yyyy-MM-dd"),
                                            VL_COTACAO = prices[j].VlrCotacao
                                        });
                                    }

                                    rangeCurrencies.RemoveAll(r => r.IdMoeda.Equals(currencyId.Cod));

                                }
                            }

                            try
                            {
                                _logger.LogInformation("Writing Result file: {time}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                FileService.WriteCsvResult(@$".\Resultado_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv", ";", result);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            

                        }
                        else
                        {
                            _logger.LogInformation("No results found in DadosMoeda.csv for currency: ::{currency}:: {time}", currency.Item.Moeda, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                _logger.LogInformation("No currency found: {time}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }

        }


    }
}