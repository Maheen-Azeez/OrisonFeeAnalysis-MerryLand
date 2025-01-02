using OrisonFeeAnalyis.Entities.General;
using OrisonFeeAnalysis.Entities.Dashboard;
using OrisonFeeAnalysis.Entities.Main;
using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logics.Contract.Main
{
    public interface IAccountsMain
    {
        public Task<IEnumerable<dtAccountsMain>> GetGridData(int BranchId, string AccYear, string SDate, string EDate,string Description, string Criteria);
        public Task<IEnumerable<dtAccountsMain>> GetDailyCollectionSummary(int BranchId, string AccYear, string SDate, string EDate,string Description);
        public Task<IEnumerable<dtAccountsMain>> GetDailyCollectionDetails(int BranchId, string AccYear, string SDate, string EDate,string Description);
        public Task<IEnumerable<dtAccountsMain>> GetCollectionSummaryTillDate(int BranchId, string AccYear, string EDate,string Description);
        public Task<IEnumerable<dtAccountsMain>> GetUserName(string Criteria);
        public Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName);
        public Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionDetails(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName);
        public Task<IEnumerable<dtAccountsMain>> GetDetailedCollection(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria);
        public Task<DashboardDetailsDto> GetDashBoardDetails(int BranchId, string AccYear, string SDate, string EDate);
        public Task<StudentCountDto> GetStudentCounts(string AccYear, string SDate, string EDate, int BranchId, string Description);



        public Task<IEnumerable<ReRegistrationPaidTcAppliedReportDto>> ReRegistrationPaidTcApplied(int BranchId, string AccYear,string paidStatus, string feeType, string Criteria);
        public Task<IEnumerable<ReservedPaymentStatusDetailedDTO>> ReservedPaymentStatusDetailed(int BranchId, string AccYear, string Criteria);
        public Task<IEnumerable<ReservedPaymentStatusSummarizedDTO>> ReservedPaymentStatusSummarized(int BranchId, string AccYear, string Criteria);
        public Task<List<string>> GetAcademicyear();
        public Task<IEnumerable<dtPaidandNotPaid>> GetPaidandNotPaid(string Academicyear,int BranchID ,string Criteria,string Class,string Division,string FeeType,string Status);
        public Task<int> GetGridCount(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria);
        public Task<IList<dtDashBoard>> GetDashBoardData(dtDashBoard dashBoard);
        public Task<IEnumerable<dtAccountsMain>> SummeryTill(int BranchId, string AccYear, string EDate, string Description, string Criteria);
        public Task<IEnumerable<dtAccountsMain>> GetGridClasswise(string AccYear, string SDate, string EDate, string Criteria);

        public Task<IEnumerable<dtAccountsMain>> GetCount(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria);
        public Task<IEnumerable<string>> GetClassandDivision(string Criteria);

        public Task<IEnumerable<dtPaidandNotPaid>> CheckUnSubmittedList(string Academicyear);

        public Task<IList<dtReciept>> GetAcknowledgmentRecieptList(DateTime FromDate, DateTime ToDate, string registerStatus, int BranchID, string dateType);

    }
}
