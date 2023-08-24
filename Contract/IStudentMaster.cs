using OrisonFeeAnalysis.Entities.General;
using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract
{
    public interface IStudentMaster
    {
        public Task<IEnumerable<dtStudentRegister>> GetStudentList(string AcademicYear, int BranchID);
        //public Task<IEnumerable<MastDesignation>> BindComboBox(string type);
        public Task<IEnumerable<SchoolClass>> GetClass(int BranchID);
        public Task<IEnumerable<SchoolClass>> GetDivision(int BranchID);
        public Task<IEnumerable<SchoolAcademicYear>> GetAcademicYear(int BranchID);
        public Task<IEnumerable<SchoolClass>> GetFee(string AcademicYear, int BranchID);
        public Task<IEnumerable<SchoolClass>> GetTransport(string AcademicYear, int BranchID);
        public Task<IEnumerable<SchoolClass>> GetAdmission(string AcademicYear, int BranchID);
        public Task<IEnumerable<SchoolClass>> GetFeeDiscount(int BranchID);
        //public Task<IEnumerable<SchoolClass>> GetActivity();
        public Task<HttpResponseMessage> Update(DtUpdate dt);
        public Task<IEnumerable<Accounts>> GetStaff(int BranchID);
        public Task<IEnumerable<dtStudentRegister>> GetParent(int BranchID);
        //public Task<IEnumerable<HrtransportationMast>> GetBusDetails(int BranchID);
        //public Task<IEnumerable<Accounts>> GetPLevel();
        public Task<string> GetPLevel();

        public Task<string> GetPLevelID();
        public Task<string> GetAccountGroup(int PID);
        public Task<string> GetSubGroup(int PID);
        public Task<string> GetAccCategory(int PID);
        public Task<string> GetShowChild(int PID);
        public Task<string> GetAccCategoryMast();
        //public Task<IEnumerable<dtCompany>> GetAbbr(int BranchID);
        public Task<string> GetAbbr(int BranchID);
        public Task<string> BindSettingsValue(string Category);





        public Task<Accounts> GetDTAccount(int AccountID);
        public Task<SchoolStudent> GetDTStudent(int AccountID);
        public Task<SchoolStudentTran> GetDTStudentTrans(int AccountID, int BranchID, string AcademicYear);
        public Task<SchoolParentMaster> GetDTParent(int AccountID);
        //public Task<SchoolStudentsArabic> GetDTStudentsArabic(int AccountID);
        //public Task<SchoolImage> GetDTStudentImage(int AccountID);

        public Task<string> GetSExistNo(int BranchID);
        public Task<string> GetNextNo(int BranchID);
        public Task<string> GetParentNextNo(int BranchID, string SCode);

        //public Task<IEnumerable<SchoolDocument>> GetStudDocumentById(int AccountID);
        //public Task<SchoolDocument> GetDocumentByDocId(int DocID);
        //Task<SchoolDocument> GetValidationByDocType(string type);
        //public Task<IEnumerable<SchoolAdditionalPayment>> GetAdditionalPayment(int AccountID);
        //public Task<IEnumerable<SchoolAdditionalPayment>> GetAdditionalDiscount(int AccountID);
        //public Task<IEnumerable<SchoolFamilyDetail>> GetRelation(int AccountID);
        //public Task<IEnumerable<SchoolStudentNote>> GetNotes(int AccountID);
        //public Task<IEnumerable<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int BranchID);
        public Task<string> GetStaffID(int BranchID, String Code);




        //public Task<HttpResponseMessage> SaveAdd(dtMasterStudent Student);
        //public Task<HttpResponseMessage> SaveSibling(dtMasterStudent Student);
        //public Task<HttpResponseMessage> SaveUpdate(dtMasterStudent Student);
        //public Task<HttpResponseMessage> UpdateStudent(dtMasterStudent Student);
        //public Task<HttpResponseMessage> SaveParent(dtMasterStudent Parent);

        //public Task<HttpResponseMessage> SaveImage(dtMasterStudent Student);
        //public Task<HttpResponseMessage> SaveUpdateImage(dtMasterStudent Student);

        //public Task<HttpResponseMessage> SaveNote(dtMasterStudent Student);
        //public Task<HttpResponseMessage> UpdateNote(dtMasterStudent Student);
        //public Task<HttpResponseMessage> DeleteNoteById(dtMasterStudent Note);

        //public Task<HttpResponseMessage> SaveRelation(dtMasterStudent Relation);
        //public Task<HttpResponseMessage> UpdateRelation(dtMasterStudent Relation);
        //public Task<HttpResponseMessage> DeleteRelationByID(dtMasterStudent Relation);

        //public Task<HttpResponseMessage> SaveDocument(dtMasterStudent Document);
        //public Task<HttpResponseMessage> UpdateDocument(dtMasterStudent Document);
        //public Task<HttpResponseMessage> DeleteDocumentByDocId(dtMasterStudent Document);

        public Task<string> GetEnableTab(string Tab);

        public Task<string> GetExistStudent(string Scode, int BranchID);

        public Task<string> GetExistParentID(string Pcode, int BranchID);

        public Task<HttpResponseMessage> ImportStudent(Accounts Data);
        //public Task<dtImportStudent> GetDTImportStudent(string Scode, int BranchID);
        public Task<string> GetTeacherName(string Class,string Division, int BranchID);
        public Task<string> GetAge(int AccountID);
    }
}
