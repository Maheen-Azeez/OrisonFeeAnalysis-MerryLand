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
    public class VoucherAllocationManager :IVoucherAllocation
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public VoucherAllocationManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<VoucherAllocation>> ShowAllocation(long AccId,  long VID)
        {
            return await httpClient.GetJsonAsync<VoucherAllocation[]>(BaseUrl + "VoucherAllocation?AccId=" + AccId +  "&VID=" + VID);
        }

        public void Dispose()
        {
            //sthrow new NotImplementedException();
        }
    }
}
