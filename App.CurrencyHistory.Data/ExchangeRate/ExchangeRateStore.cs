using System;
using System.Collections.Generic;
using App.CurrencyHistory.Data.ExchangeRate.Model;

namespace App.CurrencyHistory.Data.ExchangeRate
{
    public class ExchangeRateStore
    {
        private Dictionary<string,ExchangeRateHostApiResponse> store;
        public ExchangeRateStore()
        {
            store = new Dictionary<string, ExchangeRateHostApiResponse>();
        }

        public void Add(ExchangeRateHostApiResponse response)
        {
            lock(this)
            {
                store.Add(response.Date+"#"+response.Base, response);
            }
        }

        public ExchangeRateHostApiResponse Search(string date, string baseCurrency)
        {
            var key = date + "#" + baseCurrency;
            if (!store.ContainsKey(key))
            {
                return null;
            }
            return store[key];
        }
    }
}
