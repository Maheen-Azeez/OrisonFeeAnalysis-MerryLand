using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract.General;
using OrisonFeeAnalysis.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete.General
{
    public class VoucherMasterManager : IVoucherMasterManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public VoucherMasterManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<List<DtVoucherMaster>> ListAll(int vtype, int userid, int branchid)
        {
            // throw new NotImplementedException();
            var voucher = await httpClient.GetJsonAsync<List<DtVoucherMaster>>(BaseUrl + "VoucherMasters?vtype=" + vtype + "&userid=" + userid + "&branchid=" + branchid);
            return voucher;
        }
        public async Task<long> ListById(int vtype, int userid)
        {
            return await httpClient.GetJsonAsync<long>(BaseUrl + "vouchermasters/" + vtype + "/" + userid);
           
        }

        public async Task<List<DtVoucherMaster>> ListAllAcc(int vtype, int userid, int branchid, string Acc,string SDate,string EDate)
        {
            var voucher = await httpClient.GetJsonAsync<List<DtVoucherMaster>>(BaseUrl + "VoucherMasters/Acc?vtype=" + vtype + "&userid=" + userid + "&branchid=" + branchid + "&AccYear=" + Acc + "&SDate=" + SDate + "&EDate=" + EDate);
            return voucher;
        }
    }
}
