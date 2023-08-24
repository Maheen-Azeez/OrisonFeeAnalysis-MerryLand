using OrisonFeeAnalysis.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logic.Contract.General
{
    public interface IUserLoginManager
    {
        public Task<IEnumerable<UserLogin>> GetUserData(int UserID,int BranchID);
    }
}
