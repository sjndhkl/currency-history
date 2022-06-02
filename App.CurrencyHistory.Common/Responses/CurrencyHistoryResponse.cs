using System;
using App.CurrencyHistory.Common.Types;

namespace App.CurrencyHistory.Common.Responses
{
    public class CurrencyHistoryResponse
    {
        public DateAwareCurrencyData Max { get; set; }
        public DateAwareCurrencyData Min { get; set; }
        public decimal Avg { get; set; }
    }
}
