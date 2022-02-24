namespace CurrencyService.Models
{
    internal static class CurrencyHelper
    {

        public static List<ItemCurrency> CurrencyDePara { get; set; } = new List<ItemCurrency>()
        {
             new ItemCurrency(){Cod = "AFN", Id = 66},
             new ItemCurrency(){Cod = "ALL", Id = 49},
             new ItemCurrency(){Cod = "ANG", Id = 33},
             new ItemCurrency(){Cod = "ARS", Id = 3,},
             new ItemCurrency(){Cod = "AWG", Id = 6,},
             new ItemCurrency(){Cod = "BOB", Id = 56},
             new ItemCurrency(){Cod = "BYN", Id = 64},
             new ItemCurrency(){Cod = "CAD", Id = 25},
             new ItemCurrency(){Cod = "CDF", Id = 58},
             new ItemCurrency(){Cod = "CLP", Id = 16},
             new ItemCurrency(){Cod = "COP", Id = 37},
             new ItemCurrency(){Cod = "CRC", Id = 52},
             new ItemCurrency(){Cod = "CUP", Id = 8},
             new ItemCurrency(){Cod = "CVE", Id = 51},
             new ItemCurrency(){Cod = "CZK", Id = 29},
             new ItemCurrency(){Cod = "DJF", Id = 36},
             new ItemCurrency(){Cod = "DZD", Id = 54},
             new ItemCurrency(){Cod = "EGP", Id = 12},
             new ItemCurrency(){Cod = "EUR", Id = 20},
             new ItemCurrency(){Cod = "FJD", Id = 38},
             new ItemCurrency(){Cod = "GBP", Id = 22},
             new ItemCurrency(){Cod = "GEL", Id = 48},
             new ItemCurrency(){Cod = "GIP", Id = 18},
             new ItemCurrency(){Cod = "HTG", Id = 63},
             new ItemCurrency(){Cod = "ILS", Id = 40},
             new ItemCurrency(){Cod = "IRR", Id = 17},
             new ItemCurrency(){Cod = "ISK", Id = 11},
             new ItemCurrency(){Cod = "JPY", Id = 9},
             new ItemCurrency(){Cod = "KES", Id = 21},
             new ItemCurrency(){Cod = "KMF", Id = 19},
             new ItemCurrency(){Cod = "LBP", Id = 42},
             new ItemCurrency(){Cod = "LSL", Id = 4},
             new ItemCurrency(){Cod = "MGA", Id = 35},
             new ItemCurrency(){Cod = "MGB", Id = 26},
             new ItemCurrency(){Cod = "MMK", Id = 69},
             new ItemCurrency(){Cod = "MRO", Id = 53},
             new ItemCurrency(){Cod = "MRU", Id = 15},
             new ItemCurrency(){Cod = "MUR", Id = 7},
             new ItemCurrency(){Cod = "MXN", Id = 41},
             new ItemCurrency(){Cod = "MZN", Id = 43},
             new ItemCurrency(){Cod = "NIO", Id = 23},
             new ItemCurrency(){Cod = "NOK", Id = 62},
             new ItemCurrency(){Cod = "OMR", Id = 34},
             new ItemCurrency(){Cod = "PEN", Id = 45},
             new ItemCurrency(){Cod = "PGK", Id = 2 },
             new ItemCurrency(){Cod = "PHP", Id = 24},
             new ItemCurrency(){Cod = "RON", Id = 5 },
             new ItemCurrency(){Cod = "SAR", Id = 44},
             new ItemCurrency(){Cod = "SBD", Id = 32},
             new ItemCurrency(){Cod = "SGD", Id = 70},
             new ItemCurrency(){Cod = "SLL", Id = 10},
             new ItemCurrency(){Cod = "SOS", Id = 61},
             new ItemCurrency(){Cod = "SSP", Id = 47},
             new ItemCurrency(){Cod = "SZL", Id = 55},
             new ItemCurrency(){Cod = "THB", Id = 39},
             new ItemCurrency(){Cod = "TRY", Id = 13},
             new ItemCurrency(){Cod = "TTD", Id = 67},
             new ItemCurrency(){Cod = "UGX", Id = 59},
             new ItemCurrency(){Cod = "USD", Id = 1 },
             new ItemCurrency(){Cod = "UYU", Id = 46},
             new ItemCurrency(){Cod = "VES", Id = 68},
             new ItemCurrency(){Cod = "VUV", Id = 57},
             new ItemCurrency(){Cod = "WST", Id = 28},
             new ItemCurrency(){Cod = "XAF", Id = 30},
             new ItemCurrency(){Cod = "XAU", Id = 60},
             new ItemCurrency(){Cod = "XDR", Id = 27},
             new ItemCurrency(){Cod = "XOF", Id = 14},
             new ItemCurrency(){Cod = "XPF", Id = 50},
             new ItemCurrency(){Cod = "ZAR", Id = 65},
             new ItemCurrency(){Cod = "ZWL", Id = 3 }
        };

    }

    internal class ItemCurrency
    {
        public string Cod { get; set; }
        public int Id { get; set; }
    }
}
