using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract;
using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete
{
    public class PostingManager : IPostingManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        int vtype, feeexist, AccID, allocexist;
        public PostingManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<HttpResponseMessage> CreatePostingVoucher(dtsVoucher Voucher)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl + "Posting/post", Voucher);
        }

        public async Task<int> GetVtype(string FeeType)
        {
            vtype = await httpClient.GetFromJsonAsync<int>(BaseUrl + "Posting/vtype?FeeType=" + FeeType);
            return vtype;
        }
    }
}
