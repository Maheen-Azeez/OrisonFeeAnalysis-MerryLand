using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract.Financial.Main;
using OrisonFeeAnalysis.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete.Financial.Main
{
    public class InvAccounts : IInvAccounts
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public InvAccounts(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<dtInvAccounts>> GetAccountsByCategoryReceipt(string AccCategory, int BranchID)
        {
            return await httpClient.GetJsonAsync<dtInvAccounts[]>(BaseUrl + "dtInvAccounts/AccCategory?AccCategory=" + AccCategory + "&BranchID=" + BranchID);
        
        }

    }
}
