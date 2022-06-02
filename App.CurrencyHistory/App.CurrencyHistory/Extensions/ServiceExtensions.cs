using System;
using App.CurrencyHistory.Common.Contracts;
using App.CurrencyHistory.Data.ExchangeRate;
using Microsoft.Extensions.DependencyInjection;

namespace App.CurrencyHistory.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCurrencyDataSource(this IServiceCollection services)
        {
            services.AddSingleton<ICurrencyHistoryDataSource, ExchangeRateHostDataSource>();
        }
    }
}
