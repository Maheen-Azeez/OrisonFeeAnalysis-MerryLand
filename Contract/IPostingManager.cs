using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract
{
    public interface IPostingManager
    {
        public Task<int> GetVtype(string FeeType);
        Task<HttpResponseMessage> CreatePostingVoucher(dtsVoucher Voucher);
    }
}
