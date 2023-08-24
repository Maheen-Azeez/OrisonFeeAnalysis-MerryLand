using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    public class ReceiptService
    {
        int vtype, AccID;
        string Bal;
        private string BaseUrl;
        HttpClient http = new HttpClient();
        private readonly IConfiguration _config;
        //IDBOperation idbopn;
        public ReceiptService(HttpClient httpClient, IConfiguration config)
        {
            http = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        public async Task<object> GetBalance(long AccId, int _BranchId)
        {
            var Balc = await http.GetFromJsonAsync<object>(BaseUrl + "Balance/" + AccId + "/" + _BranchId);
            return Balc;
        }
        public async Task<object> GetBalancePayment(long AccId, int _BranchId)
        {
            var Balc = await http.GetFromJsonAsync<object>(BaseUrl + "Cheque/" + AccId + "/" + _BranchId);
            return Balc;
        }
    }
     
}