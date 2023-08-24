using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Data.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    public class UserRightsServices
    {
        private string BaseUrl;
        HttpClient http = new HttpClient();
        private readonly IConfiguration _config;
        private readonly NavigationManager navigationManager;

        public UserRightsServices(HttpClient httpClient, IConfiguration config, NavigationManager navigationManager)
        {
            http = httpClient;
            this._config = config;
            this.navigationManager = navigationManager;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<UserRights> GetUserRights(int UserID, string Keyword, string Module, int BranchId)
        {
            UserRights _UserRights = await http.GetFromJsonAsync<UserRights>(BaseUrl + "UserRights?ID=" + UserID + "&Keyword=" + Keyword + "&Module=" + Module + "&BranchId=" + BranchId);
            return _UserRights;
        }
    }
}
