using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    public class FinServices
    {
        int vtype;
        private string BaseUrl;
        HttpClient http = new HttpClient();
        private readonly IConfiguration _config;
        public FinServices(HttpClient httpClient, IConfiguration config)
        {
            http = httpClient;
            //idbopn = idb;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<VoucherDocuments>> GetAll(int _vtype)
        {
            return await http.GetJsonAsync<VoucherDocuments[]>(BaseUrl + "VoucherDoc?vtype=" + _vtype);
        }
        public async Task<int> getVtype(string val)
        {
            vtype = await http.GetFromJsonAsync<int>(BaseUrl + "Values/" + val);
            return vtype;
        }
    }
}
