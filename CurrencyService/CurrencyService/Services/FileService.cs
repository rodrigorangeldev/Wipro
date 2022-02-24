using CurrencyService.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyService.Services
{
    internal static class FileService
    {
        public static List<DadosCotacao> DadosCotacaoCsvRead(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                var list = new List<DadosCotacao>();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                for (int i = 0; !parser.EndOfData; i++)
                {
                    string[] fields = parser.ReadFields();
                    if (i > 0) //avoid header
                    {

                        list.Add(new DadosCotacao
                        {
                            VlrCotacao = fields[0],
                            CodCotacao = fields[1],
                            DatCotacao = Convert.ToDateTime(fields[2])
                        });
                    }
                }

                return list;
            }
        }

        public static List<DadosMoeda> DadosMoedaCsvRead(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                var list = new List<DadosMoeda>();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                for (int i = 0; !parser.EndOfData; i++)
                {
                    string[] fields = parser.ReadFields();
                    if (i > 0) //avoid header
                    {

                        list.Add(new DadosMoeda
                        {
                           IdMoeda = fields[0],
                           DataRef = Convert.ToDateTime(fields[1])
                        });
                    }
                }

                return list;
            }
        }

        public static void WriteCsvResult(string filePath, string delimiter, List<ResultModel> result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, "ID_MOEDA", "DATA_REF", "VL_COTACAO")); //manual header
            for (int i = 0; i < result.Count; i++)
            {
              sb.AppendLine(string.Join(delimiter, result[i].ID_MOEDA, result[i].DATA_REF, result[i].VL_COTACAO));
            }

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
