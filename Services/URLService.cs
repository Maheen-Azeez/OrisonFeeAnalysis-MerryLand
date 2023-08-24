using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace OrisonFeeAnalysis.Services
{
    public class URLService
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public URLService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<string> GetURL(string source)
        {
            return await httpClient.GetStringAsync(BaseUrl + "Portal/" + source);
        }
    }
}
