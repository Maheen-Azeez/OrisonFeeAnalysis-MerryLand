using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract.Financial.Main;
using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete.Financial.Main
{
    public class AccountAllocationManager :IAccountAllocation
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public AccountAllocationManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<VoucherAllocation>> AccountAllocation(long AccId,  long VID,int BranchID)
        {
         
            return await httpClient.GetJsonAsync<VoucherAllocation[]>(BaseUrl + "AccountAllocation?AccId=" + AccId +  "&VID=" + VID + "&BranchID=" + BranchID);
            
            //return await httpClient.GetJsonAsync<VoucherAllocation[]>(BaseUrl + "VoucherAllocation?AccId=48064&VID=10546");
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
