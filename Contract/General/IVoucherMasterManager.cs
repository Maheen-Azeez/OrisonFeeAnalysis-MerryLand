using OrisonFeeAnalysis.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.General
{
    public interface IVoucherMasterManager
    {
        Task<List<DtVoucherMaster>> ListAll(int vtype, int userid, int branchid);
        Task<List<DtVoucherMaster>> ListAllAcc(int vtype, int userid, int branchid,string Acc,string SDate,string EDate);
        Task<long> ListById(int vtype, int userid);
    }
}
