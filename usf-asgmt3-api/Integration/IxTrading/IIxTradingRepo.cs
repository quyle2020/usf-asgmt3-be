using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usf_asgmt3_api.model;

namespace usf_asgmt3_api.Integration.IxTrading
{
    public interface IIxTradingRepo
    {
        Task<List<Symbol>> GetSymbolsAsync();
        Task<List<Company_Detail>> GetCompanyDetailAsync(List<string> symbolNames);
        Task<List<Company_Dividend>> GetCompanyDividendAsync(List<string> symbolNames);

        Task<List<Company_Financial>> GetCompanyFinancialAsync(List<string> symbolNames);

    }
}
