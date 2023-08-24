using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    public class TaxInvoiceService
    {

        int vtype, AccID;
        double vNo;
        private string BaseUrl;
        HttpClient http = new HttpClient();
        private readonly IConfiguration _config;
        //IDBOperation idbopn;
        public TaxInvoiceService(HttpClient httpClient, IConfiguration config)
        {
            http = httpClient;
            //idbopn = idb;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<double> GetNextNoAsync(int vtype, int _BranchId)

        {
            vNo = await http.GetFromJsonAsync<double>(BaseUrl + "Values/" + vtype + "/" + _BranchId);
            return vNo;
        }
    }
}
