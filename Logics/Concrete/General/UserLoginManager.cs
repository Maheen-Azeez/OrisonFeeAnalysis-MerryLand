using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Entites;
using OrisonFeeAnalysis.Logic.Contract.General;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logics.Concrete.General
{
    public class UserLoginManager:IUserLoginManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public UserLoginManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        public async Task<IEnumerable<UserLogin>> GetUserData(int UserID,int BranchID)
        {
            return await httpClient.GetJsonAsync<UserLogin[]>(BaseUrl + "UserLogin?UserID=" + UserID + "&BranchID="+BranchID);
            //throw new NotImplementedException();
        }
    }
}
