using OrisonFeeAnalysis.Entities.Financial.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
   public interface IVoucherDocuments
    {
        Task DeleteDoc(int Id);
        Task<HttpResponseMessage> SaveDocs(VoucherDocuments[] vocDocs);
    }
}
