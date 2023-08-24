using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    public class GeneralServices
    {
        int vtype, AccID;
        int vNo;
        private string BaseUrl;
        HttpClient http = new HttpClient();
        private readonly IConfiguration _config;

        public GeneralServices(HttpClient httpClient, IConfiguration config)
        {
            http = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<List<VtypeTran>> getEntryMode(string EntryMode, bool FinWeb)
        {
            return await http.GetFromJsonAsync<List<VtypeTran>>(BaseUrl + "Settings/" + EntryMode + "/" + FinWeb);

        }
        public async Task<int> getVtype(string type)
        {
            vtype = await http.GetFromJsonAsync<int>(BaseUrl + "Values/" + type);
            return vtype;
        }
        public async Task<string> getBranchSettings(string category)
        {
            var value = await http.GetStringAsync(BaseUrl + "Settings?category=" + category);
            return value;
        }
        public async Task<string> getBranchSettingsRecpt(string category)
        {
            var value = await http.GetStringAsync(BaseUrl + "Settings?category=" + category);
            return value;
        }

    }
}
