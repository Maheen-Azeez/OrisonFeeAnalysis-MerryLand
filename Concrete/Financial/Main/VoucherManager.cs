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
    public class VoucherManager : IVoucher
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public VoucherManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<Voucher> ShowVoucher(long VId)
        {
            return await httpClient.GetJsonAsync<Voucher>(BaseUrl + "Voucher?VId=" + VId);
        }
        public async Task<Voucher> VoucherImport(long VId)
        {
            return await httpClient.GetJsonAsync<Voucher>(BaseUrl + "Voucher?VId=" + VId);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
