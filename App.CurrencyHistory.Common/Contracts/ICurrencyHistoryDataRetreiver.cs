using System;
using System.Threading.Tasks;
using App.CurrencyHistory.Common.Requests;
using App.CurrencyHistory.Common.Responses;

namespace App.CurrencyHistory.Common.Contracts
{
    public interface ICurrencyHistoryDataSource
    {
        Task<CurrencyHistoryResponse> get(CurrencyHistoryRequest request);
    }
}
