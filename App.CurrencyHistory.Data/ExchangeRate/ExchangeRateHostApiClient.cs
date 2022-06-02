using System;
using System.Net.Http;
using System.Threading.Tasks;
using App.CurrencyHistory.Data.ExchangeRate.Model;
using System.Net.Http.Json;

namespace App.CurrencyHistory.Data.ExchangeRate
{
    public class ExchangeRateHostApiClient
    {
        private HttpClient httpClient;

        public ExchangeRateHostApiClient()
        { 
          httpClient = new HttpClient();
        }

        public async Task<ExchangeRateHostApiResponse> CallAsync(string baseCurrency, string date)
        {
            string apiUrl = string.Format("https://api.exchangerate.host/{0}?base={1}", date, baseCurrency);
            return await httpClient.GetFromJsonAsync<ExchangeRateHostApiResponse>(apiUrl);
        }

    }
}
