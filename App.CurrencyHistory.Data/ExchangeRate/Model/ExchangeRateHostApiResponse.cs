using System;
using System.Collections.Generic;

namespace App.CurrencyHistory.Data.ExchangeRate.Model
{
    public class ExchangeRateHostApiResponse
    {

        public bool Success { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string,decimal> Rates { get; set; }
       
    }
}
