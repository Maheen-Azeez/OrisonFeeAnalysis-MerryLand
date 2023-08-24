using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalyis.Entities.General;
using OrisonFeeAnalysis.Entities.Main;
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
		
		public async Task<IEnumerable<dtAccountsMain>> GetUserwiseCollectionSummary(int BranchId, string AccYear, string SDate, string EDate, string Description, string Criteria, string userName)
        {
            try
            {
                var GridData = httpClient.GetJsonAsync<IEnumerable<dtAccountsMain>>(BaseUrl + "AccountsMain/GetUserwiseCollectionSummary?BranchId=" + BranchId + "&AccYear=" + AccYear + "&SDate=" + SDate + "&EDate=" + EDate + "&Description=" + Description + "&Criteria=" + Criteria+"&userName="+userName);
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

        public async Task<IList<dtReciept>> GetAcknowledgmentRecieptList(DateTime FromDate, DateTime ToDate, string Criteria, int BranchID, string academiYear)
        {
            try
            {
                var AcknowledgmentRecieptList = httpClient.GetJsonAsync<List<dtReciept>>(BaseUrl + "AccountsMain/GetAcknowledgmentRecieptList?FromDate=" + FromDate +"&ToDate="+ToDate+ "&Criteria=" + Criteria+"&BranchID="+BranchID + "&academicYear=" + academiYear);
                return await AcknowledgmentRecieptList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
