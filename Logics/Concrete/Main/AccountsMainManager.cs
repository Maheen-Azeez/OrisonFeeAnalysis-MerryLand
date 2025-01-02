using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalyis.Entities.General;
using OrisonFeeAnalysis.Entities.Dashboard;
using OrisonFeeAnalysis.Entities.Main;
using OrisonFeeAnalysis.Entities.Student;
using OrisonFeeAnalysis.Logics.Contract.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Logics.Concrete.Main
{
    public class AccountsMainManager : IAccountsMain
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public AccountsMainManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        public async Task<IEnumerable<dtAccountsMain>> GetGridData(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl+ "AccountsMain/GetGridData?BranchId=" + BranchId+ "&AccYear="+AccYear+"&SDate="+SDate+"&EDate="+EDate+"&Description="+Description+"&Criteria="+Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IEnumerable<dtAccountsMain>> GetDailyCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl+ "AccountsMain/DailyCollectionSummary?BranchId=" + BranchId+ "&AccYear="+AccYear+"&SDate="+SDate+"&EDate="+EDate+"&Description="+Description);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IEnumerable<dtAccountsMain>> GetDailyCollectionDetails(int BranchId, string AccYear, string SDate, string EDate, string Description)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl+ "AccountsMain/DailyCollectionDetails?BranchId=" + BranchId+ "&AccYear="+AccYear+"&SDate="+SDate+"&EDate="+EDate+"&Description="+Description);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IEnumerable<dtAccountsMain>> GetCollectionSummaryTillDate(int BranchId, string AccYear, string EDate, string Description)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/CollectionSummaryTillDate?BranchId=" + BranchId + "&AccYear=" + AccYear + "&EDate=" + EDate + "&Description=" + Description);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/UserwiseCollectionSummary?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria + "&userName=" + userName);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionDetails(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/UserwiseCollectionDetails?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria + "&userName=" + userName);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<dtAccountsMain>> GetDetailedCollection(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/DetailedCollection?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<DashboardDetailsDto> GetDashBoardDetails(int BranchId, string AccYear, string SDate, string EDate)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<DashboardDetailsDto>(BaseUrl + "AccountsMain/DashBoardDetails?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<StudentCountDto> GetStudentCounts(string AccYear, string SDate, string EDate, int BranchId, string Description)
        {

            try
            {
                var Result = httpClient.GetJsonAsync<StudentCountDto>(BaseUrl + "AccountsMain/StudentCount?AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&BranchId=" + BranchId + "&Description=" + Description);
                return await Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public async Task<IEnumerable<ReRegistrationPaidTcAppliedReportDto>> ReRegistrationPaidTcApplied(int BranchId, string AccYear, string paidStatus, string feeType, string Criteria)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<ReRegistrationPaidTcAppliedReportDto>>(BaseUrl+ "AccountsMain/ReRegistrationPaidTcApplied?BranchId=" + BranchId+ "&AccYear="+AccYear + "&paidStatus=" + paidStatus + "&feeType=" + feeType + "&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> GetGridCount(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria)
        {
            try
            {
                var StudentCount = httpClient.GetJsonAsync<int>(BaseUrl + "AccountsMain/GetGridDataCount?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria);
                return await StudentCount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IList<dtDashBoard>> GetDashBoardData(dtDashBoard dashBoard)
        {
            try
            {
                return await httpClient.PostJsonAsync<IList<dtDashBoard>>(BaseUrl + "AccountsMain/GetDashBoardData", dashBoard);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<dtAccountsMain>> SummeryTill(int BranchId, string AccYear, string EDate, string Description, string Criteria)
        {

            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/SummeryTill?BranchId=" + BranchId + "&AccYear=" + AccYear + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<dtAccountsMain>> GetGridClasswise(string AccYear, string SDate, string EDate, string Criteria)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/GetGridClasswiseReReg?AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<dtAccountsMain>> GetUserName(string Criteria)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/GetUserName?&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<dtPaidandNotPaid>> GetPaidandNotPaid(string Academicyear, int BranchID , string Criteria, string Class, string Division, string FeeType, string Status)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtPaidandNotPaid>>(BaseUrl + "AccountsMain/GetPaidandNotPaid?Academicyear=" + Academicyear + "&BranchID=" + BranchID + "&Criteria=" + Criteria+"&Class="+Class+"&Division="+Division+"&FeeType="+FeeType+"&Status="+Status);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<string>> GetAcademicyear()
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<List<string>>(BaseUrl + "AccountsMain/GetAcademicyear");
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
		
		

        public async Task<IEnumerable<dtAccountsMain>> GetCount(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria)
        {
            try
            {
                var StudentCount = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/GetCount?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria);
                return await StudentCount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<string>> GetClassandDivision(string Criteria)
        {
            try
            {
                var ClassandDivisionList = httpClient.GetJsonAsync<IEnumerable<string>>(BaseUrl + "AccountsMain/GetClassandDivision?Criteria=" + Criteria);
                return await ClassandDivisionList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<dtPaidandNotPaid>> CheckUnSubmittedList(string Academicyear)
        {
            try
            {
                var UnSubmittedList = httpClient.GetJsonAsync<IEnumerable<dtPaidandNotPaid>>(BaseUrl + "AccountsMain/GetCheckNotSubmittedList?Academicyear=" + Academicyear);
                return await UnSubmittedList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IList<dtReciept>> GetAcknowledgmentRecieptList(DateTime FromDate, DateTime ToDate, string registerStatus, int BranchID, string dateType)
        {
            try
            {
                var AcknowledgmentRecieptList = httpClient.GetJsonAsync<List<dtReciept>>(BaseUrl + "AccountsMain/GetAcknowledgmentRecieptList?FromDate=" + FromDate +"&ToDate="+ToDate+ "&registerStatus=" + registerStatus + "&BranchID="+BranchID + "&dateType=" + dateType);
                return await AcknowledgmentRecieptList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ReservedPaymentStatusDetailedDTO>> ReservedPaymentStatusDetailed(int BranchId, string AccYear, string Criteria)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<ReservedPaymentStatusDetailedDTO>>(BaseUrl + "AccountsMain/ReservedPaymentStatusDetailed?BranchId=" + BranchId + "&AccYear=" + AccYear + "&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ReservedPaymentStatusSummarizedDTO>> ReservedPaymentStatusSummarized(int BranchId, string AccYear, string Criteria)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<ReservedPaymentStatusSummarizedDTO>>(BaseUrl + "AccountsMain/ReservedPaymentStatusSummarized?BranchId=" + BranchId + "&AccYear=" + AccYear + "&Criteria=" + Criteria);
                return await GridData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
