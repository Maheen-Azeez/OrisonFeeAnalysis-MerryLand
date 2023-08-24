using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract.Financial.Main;
using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete.Financial.Main
{
    public class VoucherDocumentsManager : IVoucherDocuments
    {
        private HttpClient httpClient;
        private IConfiguration _config;
        private string BaseUrl;
        public VoucherDocumentsManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<HttpResponseMessage> SaveDocs(VoucherDocuments[] vocDocs)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl + "VoucherDoc", vocDocs);
        }
        public async Task DeleteDoc(int Id)
        {
            await httpClient.DeleteAsync(BaseUrl + "VoucherDoc/" + Id);
        }

    }
}
