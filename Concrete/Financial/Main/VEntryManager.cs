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
    public class VEntryManager:IVEntry
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public VEntryManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<dtfinVEntry>> Show(long VId)
        {
            return await httpClient.GetJsonAsync<dtfinVEntry[]>(BaseUrl + "VEntry?VId=" + VId);
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
