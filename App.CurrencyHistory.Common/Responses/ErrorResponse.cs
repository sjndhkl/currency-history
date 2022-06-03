using System;
using System.Text.Json;

namespace App.CurrencyHistory.Common.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
