using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract
{
    public interface IOptionalManager
    {
        public Task<List<CceElectiveSubjectChild>> Getdata(string StudentCode);
        public Task<List<CceElectiveSubjectChild>> Getdatas(int BranchID, string AcademicYear, string StudentCode);
        public Task<List<CceElectiveSubjectMaster>> Getamts();
        public Task<List<CceElectiveSubjectMaster>> GetOption(int BranchID, string AcademicYear, string cls);
        public Task<CceElectiveSubjectMaster> GetOptions(int BranchID, string AcademicYear, string cls);
        public Task<CceElectiveSubjectChild> countalevel(int BranchID, string StudentCode);
        public Task<CceElectiveSubjectChild> countigcse(int BranchID, string StudentCode);
        public Task<CceElectiveSubjectMaster> getdate();
        public Task<CceElectiveSubjectMaster> getExam();


        public Task<CceElectiveSubjectChild> subtt(int BranchID, string StudentCode, int Idne);
        public Task<CceElectiveSubjectParent> idnew();
        public Task<CceElectiveSubjectChild> countaslevel(int BranchID, string StudentCode);
        public Task<CceElectiveSubjectParent> finesum(int BranchID, string StudentCode);
        public Task<CceElectiveSubjectParent> revaluationsum(int BranchID, string StudentCode);
        public Task<List<CceElectiveSubjectMaster>> GetOption1(int BranchID, string AcademicYear);
        public Task<List<CceElectiveSubjectMaster>> GetOption2(int BranchID, string AcademicYear);
        public Task<List<CceElectiveSubjectMaster>> Getsubject(int BranchID, string Op, string AcademicYear);
        public Task<List<CceElectiveSubjectMaster>> Getamount(int BranchID, string Op, string AcademicYear);
        public Task<IEnumerable<dtStudentRegister>> GetStudentss(int BranchID, string AcademicYear, string cls, string div);
        Task<bool> DeleteMaster(int Id);
        public Task<HttpResponseMessage> SaveOptinal(CceElectiveSubjectChild value);
        public Task<HttpResponseMessage> SaveDate(CceElectiveSubjectMaster value);
        public Task<HttpResponseMessage> SAVEEXAM(CceElectiveSubjectMaster value);


        public Task<List<CceElectiveSubjectChild>> GetAll(int BranchID, string AcademicYear, string Category, int UserID);
        public Task<List<CceElectiveSubjectChild>> Getreexam(int BranchID, string AcademicYear, string Category, int UserID);

        public Task<HttpResponseMessage> Savefees(CceElectiveSubjectParent value);
        public Task<List<CceElectiveSubjectParent>> Getfeedata(int BranchID, string AcademicYear, string StudentCode);
        Task<bool> Deletefee(int Id);
        public Task<HttpResponseMessage> UpdatePost(CceElectiveSubjectChild value);

    }

}
