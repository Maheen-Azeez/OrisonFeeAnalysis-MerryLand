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
    public class ChequeManager : ICheque
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public ChequeManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<Cheque>> ShowCheque( long VID)
        {
            return await httpClient.GetJsonAsync<Cheque[]>(BaseUrl + "Cheque?VId="  + VID);
        }
        public async Task<IEnumerable<Cheque>> ShowChequePayment(long VID)
        {
            return await httpClient.GetJsonAsync<Cheque[]>(BaseUrl + "Cheque/Payment?VId=" + VID);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
