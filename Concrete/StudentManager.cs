using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract;
using OrisonFeeAnalysis.Data;
using OrisonFeeAnalysis.Entities;
using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace OrisonFeeAnalysis.Concrete
{
    public class StudentManager : IStudentManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        HttpClient httpClient = new HttpClient();
        public StudentManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        //public async Task<IEnumerable<dtStudentRegister>> GetStudents(string AcademicYear, int BranchID, string Category, int UserID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Student?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID);
        //}
        //public async Task<IEnumerable<dtStudentRegister>> GetStudentRegisterAll(string AcademicYear, int BranchID, string Category, int UserID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Student/StudentAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID);
        //}
        //public async Task<IEnumerable<dtStudentRegister>> GetStudentRegisterCustomized(string AcademicYear, int BranchID, string Category, int UserID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Student/StudentCustomized?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID);
        //}
        //public async Task<IEnumerable<dtStudentRegister>> GetStudentRegisterCustomizedAll(string AcademicYear, int BranchID, string Category, int UserID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Student/StudentCustomizedAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID);
        //}
        //public async Task<IEnumerable<dtStudentRegister>> GetStudentRegisterDetailed(string AcademicYear, int BranchID, string Category, int UserID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Student/StudentDetailed?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID);
        //}
        //public async Task<IEnumerable<dtStudentRegister>> GetStudentRegisterDetailedAll(string AcademicYear, int BranchID, string Category, int UserID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Student/StudentDetailedAll?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&Category=" + Category + "&UserID=" + UserID);
        //}
        public async Task<IEnumerable<SchoolAcademicYear>> GetAcademicYear(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolAcademicYear>>(BaseUrl + "DB?BranchID=" + BranchID);
        }
        public async Task<string> GetCurrentAcademicYear(int BranchID)
        {
            var AcademicYear = await httpClient.GetStringAsync(BaseUrl + "DB/CurrentYear?BranchID=" + BranchID);
            return AcademicYear;
        }
        public async Task<string> GetSchool()
        {
            var School = await httpClient.GetStringAsync(BaseUrl + "DB/School");
            return School;
        }

        public async Task<string> GetCompany(int BranchID)
        {
            var School = await httpClient.GetStringAsync(BaseUrl + "DB/Company?BranchID=" + BranchID);
            return School;
        }

        public async Task<string> getHomeUrl()
        {
            var Logo = await httpClient.GetStringAsync(BaseUrl + "Home");
            return Logo;
        }

        public async Task<string> getLogoutUrl()
        {
            var Logo = await httpClient.GetStringAsync(BaseUrl + "LogOut");
            return Logo;
        }

        public async Task<string> getLogo(int BranchID)
        {
            var Logo = await httpClient.GetStringAsync(BaseUrl + "Home/Logo?BranchID=" + BranchID);
            return Logo;
        }

        public async Task<string> getLogoUrl()
        {
            var Logo = await httpClient.GetStringAsync(BaseUrl + "Home/LogoUrl");
            return Logo;
        }

        //public async Task<HttpResponseMessage> SaveSyncData(dtSyncData Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "Student/BulkSync", Student);
        //}
    }
}
