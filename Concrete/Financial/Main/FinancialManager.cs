using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract.Financial.Main;
using OrisonFeeAnalysis.Entities.Financial.Main;
using OrisonFeeAnalysis.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete.Financial.Main
{
    public class FinancialManager : IFinancialManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public FinancialManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        //public async Task<HttpResponseMessage> CreateFinancial(dtsFinancial financial)
        //{
        //    HttpResponseMessage response;
        //    response = await httpClient.PostAsJsonAsync(BaseUrl + "Financial", financial);
        //    //long VID = 0;
        //    //var data = await response.Content.ReadFromJsonAsync<resultID>();
        //    //VID = data.ID;
        //    //return VID;
        //    return response;
        //}
        public async Task<long> CreateFinancial(dtsFinancial financial)
        {
            HttpResponseMessage response;
            response = await httpClient.PostAsJsonAsync(BaseUrl + "Financial", financial);
            long VID = 0;
            var data = await response.Content.ReadFromJsonAsync<resultID>();
            VID = data.ID;
            return VID;

        }

    }
}
