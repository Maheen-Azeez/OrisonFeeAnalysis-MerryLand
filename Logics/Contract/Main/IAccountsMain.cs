using OrisonFeeAnalyis.Entities.General;
using OrisonFeeAnalysis.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logics.Contract.Main
{
    public interface IAccountsMain
    {
        public Task<IEnumerable<dtAccountsMain>> GetGridData(int BranchId, string AccYear, string SDate, string EDate,string Description, string Criteria);
        public Task<IEnumerable<dtAccountsMain>> GetUserName(string Criteria);
        public Task<List<string>> GetAcademicyear();
        public Task<IEnumerable<dtPaidandNotPaid>> GetPaidandNotPaid(string Academicyear,int BranchID ,string Criteria,string Class,string Division,string FeeType,string Status);
        public Task<int> GetGridCount(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria);
        public Task<IList<dtDashBoard>> GetDashBoardData(dtDashBoard dashBoard);
        public Task<IEnumerable<dtAccountsMain>> SummeryTill(int BranchId, string AccYear, string EDate, string Description, string Criteria);
        public Task<IEnumerable<dtAccountsMain>> GetGridClasswise(string AccYear, string SDate, string EDate, string Criteria);
		public Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria,string userName);

        public Task<IEnumerable<dtAccountsMain>> GetCount(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria);
        public Task<IEnumerable<string>> GetClassandDivision(string Criteria);

        public Task<IEnumerable<dtPaidandNotPaid>> CheckUnSubmittedList(string Academicyear);

        public Task<IList<dtReciept>> GetAcknowledgmentRecieptList(DateTime FromDate, DateTime ToDate, string Criteria, int BranchID,string academiYear);

    }
}
