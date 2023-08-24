using OrisonFeeAnalysis.Entities.Student;
using OrisonFeeAnalysis.Data;
using OrisonFeeAnalysis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract
{
    public interface IStudentManager
    {
        //public Task<IEnumerable<dtStudentRegister>> GetStudents(string AcademicYear, int BranchID, string Category, int UserID);
        //public Task<IEnumerable<dtStudentRegister>> GetStudentRegisterAll(string AcademicYear, int BranchID, string Category, int UserID);
        //public Task<IEnumerable<dtStudentRegister>> GetStudentRegisterCustomized(string AcademicYear, int BranchID, string Category, int UserID);
        //public Task<IEnumerable<dtStudentRegister>> GetStudentRegisterCustomizedAll(string AcademicYear, int BranchID, string Category, int UserID);
        //public Task<IEnumerable<dtStudentRegister>> GetStudentRegisterDetailed(string AcademicYear, int BranchID, string Category, int UserID);
        //public Task<IEnumerable<dtStudentRegister>> GetStudentRegisterDetailedAll(string AcademicYear, int BranchID, string Category, int UserID);
        public Task<IEnumerable<SchoolAcademicYear>> GetAcademicYear(int BranchID);
        public Task<string> GetCurrentAcademicYear(int BranchID);
        public Task<string> GetSchool();
        public Task<string> GetCompany(int BranchID);
        public Task<string> getHomeUrl();
        public Task<string> getLogoutUrl();

        public Task<string> getLogo(int BranchID);
        public Task<string> getLogoUrl();

        //public Task<HttpResponseMessage> SaveSyncData(dtSyncData Student);
    }
}
