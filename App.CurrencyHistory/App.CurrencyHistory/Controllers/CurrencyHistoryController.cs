using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.CurrencyHistory.Common.Responses;
using App.CurrencyHistory.Common.Contracts;
using App.CurrencyHistory.Common.Requests;

namespace App.CurrencyHistory.Controllers
{
   
    [ApiController]
    [Route("/api/v1/currency/history/{base?}/{target?}/{dates?}")]
    public class CurrencyHistoryController : ControllerBase
    {
        private readonly ICurrencyHistoryDataSource currencyHistoryDataSource;

        public CurrencyHistoryController(ICurrencyHistoryDataSource currencyHistoryDataSource)
        {
            this.currencyHistoryDataSource = currencyHistoryDataSource;
        }

        [HttpGet]
        public async Task<CurrencyHistoryResponse> GetAsync([FromRoute] CurrencyHistoryRequest request)
        {
           var response = await currencyHistoryDataSource.get(request);
           return response;
        }
    }
}
