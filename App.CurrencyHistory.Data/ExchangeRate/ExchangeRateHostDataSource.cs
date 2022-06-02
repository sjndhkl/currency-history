using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.CurrencyHistory.Common.Contracts;
using App.CurrencyHistory.Common.Requests;
using App.CurrencyHistory.Common.Responses;
using App.CurrencyHistory.Common.Types;

namespace App.CurrencyHistory.Data.ExchangeRate
{
    public class ExchangeRateHostDataSource : ICurrencyHistoryDataSource
    {
        private ExchangeRateStore store;
        private ExchangeRateHostApiClient client;

        public ExchangeRateHostDataSource()
        {
            store = new ExchangeRateStore();
        }

        public async Task<CurrencyHistoryResponse> get(CurrencyHistoryRequest request)
        {
            var max = new DateAwareCurrencyData();
            var min = new DateAwareCurrencyData();
            min.Value = 99999;
            decimal sum = 0M;

            foreach (string date in request.DateList)
            {
                Model.ExchangeRateHostApiResponse response = await ReadRecord(request.Base, date);

                var currentValue = response.Rates[request.Target];
                sum += currentValue;
                if (max.Value < currentValue)
                {
                    max.Date = date;
                    max.Value = currentValue;
                }

                if (min.Value > currentValue)
                {
                    min.Date = date;
                    min.Value = currentValue;
                }
            }

            return new CurrencyHistoryResponse() { Max = max, Min = min, Avg = sum/request.DateList.Count };
        }

        private async Task<Model.ExchangeRateHostApiResponse> ReadRecord(string baseCurrency, string date)
        {
            var response = store.Search(date, baseCurrency);
            if (null == response)
            {
                if (null == client)
                {
                    client = new ExchangeRateHostApiClient();
                }

                response = await client.CallAsync(baseCurrency, date);
                if (response.Success)
                {
                    store.Add(response);
                }
            }

            return response;
        }
    }
}
