using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract;
using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete
{
    public class OptionalManager : IOptionalManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        HttpClient httpClient = new HttpClient();
        public OptionalManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<List<CceElectiveSubjectChild>> Getdatas(int BranchID, string AcademicYear, string StudentCode)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectChild>>(BaseUrl + "OptionalManager/Gets?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&StudentCode=" + StudentCode);
        }
        public async Task<List<CceElectiveSubjectChild>> Getdata(string StudentCode)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectChild>>(BaseUrl + "OptionalManager/Get?StudentCode=" + StudentCode);
        }
        public async Task<List<CceElectiveSubjectMaster>> Getamts()
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectMaster>>(BaseUrl + "OptionalManager/Getamts?");
        }
        public async Task<CceElectiveSubjectChild> countigcse(int BranchID, string StudentCode)
        {
            try
            {
                var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectChild>(BaseUrl + "OptionalManager/Getcountigcse?BranchID=" + BranchID + "&StudentCode=" + StudentCode);
                return Student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CceElectiveSubjectChild> countaslevel(int BranchID, string StudentCode)
        {
            try
            {
                var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectChild>(BaseUrl + "OptionalManager/Getcountaslevel?BranchID=" + BranchID + "&StudentCode=" + StudentCode);
                return Student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CceElectiveSubjectChild> countalevel(int BranchID, string StudentCode)
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectChild>(BaseUrl + "OptionalManager/Getcountalevel?BranchID=" + BranchID + "&StudentCode=" + StudentCode);
            return Student;
        }
        public async Task<CceElectiveSubjectChild> subtt(int BranchID, string StudentCode, int Idne)
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectChild>(BaseUrl + "OptionalManager/subtt?BranchID=" + BranchID + "&StudentCode=" + StudentCode + "&Idne=" + Idne);
            return Student;
        }
        public async Task<CceElectiveSubjectParent> idnew()
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectParent>(BaseUrl + "OptionalManager/idnew?");
            return Student;
        }
        public async Task<CceElectiveSubjectParent> finesum(int BranchID, string StudentCode)
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectParent>(BaseUrl + "OptionalManager/finesum?BranchID=" + BranchID + "&StudentCode=" + StudentCode);
            return Student;
        }
        public async Task<CceElectiveSubjectParent> revaluationsum(int BranchID, string StudentCode)
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectParent>(BaseUrl + "OptionalManager/revaluationsum?BranchID=" + BranchID + "&StudentCode=" + StudentCode);
            return Student;
        }
        public async Task<CceElectiveSubjectMaster> getdate()
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectMaster>(BaseUrl + "OptionalManager/getdate?" );
            return Student;
        }

        public async Task<CceElectiveSubjectMaster> getExam()
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectMaster>(BaseUrl + "OptionalManager/getExam?");
            return Student;
        }
        public async Task<List<CceElectiveSubjectMaster>> GetOption(int BranchID, string AcademicYear, string cls)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectMaster>>(BaseUrl + "OptionalManager/GetOption?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&cls=" + cls);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CceElectiveSubjectMaster> GetOptions(int BranchID, string AcademicYear, string cls)
        {
            var Student = await httpClient.GetFromJsonAsync<CceElectiveSubjectMaster>(BaseUrl + "OptionalManager/GetOptions?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&cls=" + cls);
            return Student;
        }
        public async Task<List<CceElectiveSubjectMaster>> GetOption1(int BranchID, string AcademicYear)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectMaster>>(BaseUrl + "OptionalManager/GetOption1?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CceElectiveSubjectMaster>> GetOption2(int BranchID, string AcademicYear)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectMaster>>(BaseUrl + "OptionalManager/GetOption2?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<dtStudentRegister>> GetStudentss(int BranchID, string AcademicYear, string cls, string div)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "OptionalManager/Students?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&cls=" + cls + "&div=" + div);
        }
        public async Task<List<CceElectiveSubjectMaster>> Getsubject(int BranchID, string Op, string AcademicYear)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectMaster>>(BaseUrl + "OptionalManager/Getsubject?BranchID=" + BranchID + "&Op=" + Op + "&AcademicYear=" + AcademicYear);
        }

        public async Task<List<CceElectiveSubjectMaster>> Getamount(int BranchID, string Op, string AcademicYear)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectMaster>>(BaseUrl + "OptionalManager/Getamount?BranchID=" + BranchID + "&Op=" + Op + "&AcademicYear=" + AcademicYear);
        }

        public async Task<HttpResponseMessage> SaveOptinal(CceElectiveSubjectChild value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "OptionalManager/Save", value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
        public async Task<HttpResponseMessage> SaveDate(CceElectiveSubjectMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "OptionalManager/SaveDate", value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
        public async Task<HttpResponseMessage> SAVEEXAM(CceElectiveSubjectMaster value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "OptionalManager/SAVEEXAM", value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
        public async Task<HttpResponseMessage> UpdatePost(CceElectiveSubjectChild value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "OptionalManager/UpdatePost", value);

            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return res;
        }
        public async Task<HttpResponseMessage> Savefees(CceElectiveSubjectParent value)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "OptionalManager/Savefees", value);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }
        async Task<bool> IOptionalManager.Deletefee(int Id)
        {
            try
            {
                await httpClient.DeleteAsync(BaseUrl + "OptionalManager/Deletes?Id=" + Id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<CceElectiveSubjectParent>> Getfeedata(int BranchID, string AcademicYear, string StudentCode)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectParent>>(BaseUrl + "OptionalManager/Getfeedata?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&StudentCode=" + StudentCode);
        }
        public async Task<List<CceElectiveSubjectChild>> GetAll(int BranchID, string AcademicYear, string Category, int UserID)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectChild>>(BaseUrl + "OptionalManager/GetAll?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Category=" + Category + "&UserID=" + UserID);
        }
        public async Task<List<CceElectiveSubjectChild>> Getreexam(int BranchID, string AcademicYear, string Category, int UserID)
        {
            return await httpClient.GetFromJsonAsync<List<CceElectiveSubjectChild>>(BaseUrl + "OptionalManager/Getreexam?BranchID=" + BranchID + "&AcademicYear=" + AcademicYear + "&Category=" + Category + "&UserID=" + UserID);
        }

        async Task<bool> IOptionalManager.DeleteMaster(int Etid)
        {
            try
            {
                await httpClient.DeleteAsync(BaseUrl + "OptionalManager/Delete?Etid=" + Etid);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
