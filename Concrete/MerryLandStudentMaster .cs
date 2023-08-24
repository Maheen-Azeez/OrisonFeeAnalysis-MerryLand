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
    public class MerryLandStudentMaster : IMerryLandStudentMaster
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        HttpClient httpClient = new HttpClient();
        public MerryLandStudentMaster(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        public async Task<IEnumerable<dtStudentRegister>> GetStudentList(string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "MerryLandStudentMaster/StudentList?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }
        public async Task<IEnumerable<dtStudentRegister>> GetStudentListTeacher(string AcademicYear, int BranchID, int UserID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "DB/StudentListOwnClass?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID + "&UserID=" + UserID);
        }
        public async Task<IEnumerable<MastDesignation>> BindComboBox(string type)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<MastDesignation>>(BaseUrl + "DB/BindComboBox?type=" + type);
        }
        public async Task<IEnumerable<SchoolAcademicYear>> GetAcademicYear(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolAcademicYear>>(BaseUrl + "DB?BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetClass(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/Class?BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetDivision(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/Division?BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetDivisionByClass(int BranchID, string Class)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/DivisionByClass?BranchID=" + BranchID + "&Class=" + Class);
        }
        public async Task<IEnumerable<SchoolClass>> GetFee(string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/Fee?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetTransport(string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/Transport?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetAdmission(string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/Admission?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetFeeDiscount(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/FeeDiscount?BranchID=" + BranchID);
        }

        public async Task<IEnumerable<SchoolClass>> GetActivity(string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "DB/Activity?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }

        public async Task<IEnumerable<Accounts>> GetStaff(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>(BaseUrl + "DB/Staff?BranchID=" + BranchID);
        }

        public async Task<IEnumerable<dtStudentRegister>> GetParent(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "DB/Parent?BranchID=" + BranchID);
        }

        public async Task<IEnumerable<HrtransportationMast>> GetBusDetails(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<HrtransportationMast>>(BaseUrl + "DB/BusDetails?BranchID=" + BranchID);
        }

        //public async Task<IEnumerable<Accounts>> GetPLevel()
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>(BaseUrl + "DB/PLevel");
        //}

        public async Task<string> GetPLevel()
        {
            //return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>(BaseUrl + "DB/PLevel");
            var Plevel = await httpClient.GetStringAsync(BaseUrl + "DB/PLevel");
            return Plevel;
        }

        public async Task<string> GetPLevelID()
        {
            var PLevelID = await httpClient.GetStringAsync(BaseUrl + "DB/PLevelID");
            return PLevelID;
        }

        public async Task<string> GetAccountGroup(int PID)
        {
            var AccountGroup = await httpClient.GetStringAsync(BaseUrl + "DB/AccountGroup?PID=" + PID);
            return AccountGroup;
        }

        public async Task<string> GetSubGroup(int PID)
        {
            var SubGroup = await httpClient.GetStringAsync(BaseUrl + "DB/SubGroup?PID=" + PID);
            return SubGroup;
        }

        public async Task<string> GetAccCategory(int PID)
        {
            var AccCategory = await httpClient.GetStringAsync(BaseUrl + "DB/AccCategory?PID=" + PID);
            return AccCategory;
        }

        public async Task<string> GetShowChild(int PID)
        {
            var ShowChild = await httpClient.GetStringAsync(BaseUrl + "DB/ShowChild?PID=" + PID);
            return ShowChild;
        }

        public async Task<string> GetAccCategoryMast()
        {
            var AccCategoryMast = await httpClient.GetStringAsync(BaseUrl + "DB/AccCategoryMast");
            return AccCategoryMast;
        }
        //public async Task<IEnumerable<dtCompany>> GetAbbr(int BranchID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<dtCompany>>(BaseUrl + "DB/Abbr?BranchID=" + BranchID);
        //}
        public async Task<string> GetAbbr(int BranchID)
        {
            var Abbr = await httpClient.GetStringAsync(BaseUrl + "DB/Abbr?BranchID=" + BranchID);
            return Abbr;
        }

        public async Task<string> BindSettingsValue(string Category)
        {
            var Value = await httpClient.GetStringAsync(BaseUrl + "DB/Setting?Category=" + Category);
            return Value;
        }








        public async Task<Accounts> GetDTAccount(int AccountID)
        {
            var Account = await httpClient.GetFromJsonAsync<Accounts>(BaseUrl + "MerryLandStudentMaster/" + AccountID);
            return Account;
        }
        public async Task<SchoolStudent> GetDTStudent(int AccountID)
        {
            var Student = await httpClient.GetFromJsonAsync<SchoolStudent>(BaseUrl + "MerryLandStudentMaster/Student/" + AccountID);
            return Student;
        }
        public async Task<SchoolStudentTran> GetDTStudentTrans(int AccountID, int BranchID, string AcademicYear)
        {
            try
            {
                var StudentTrans = await httpClient.GetFromJsonAsync<SchoolStudentTran>(BaseUrl + "MerryLandStudentMaster/StudentTrans/" + AccountID + "/" + BranchID + "/" + AcademicYear);
                return StudentTrans;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        public async Task<SchoolParentMaster> GetDTParent(int AccountID)
        {
            var Student = await httpClient.GetFromJsonAsync<SchoolParentMaster>(BaseUrl + "MerryLandStudentMaster/Parent/" + AccountID);
            return Student;
        }
        public async Task<SchoolStudentsArabic> GetDTStudentsArabic(int AccountID)
        {
            var Student = await httpClient.GetFromJsonAsync<SchoolStudentsArabic>(BaseUrl + "MerryLandStudentMaster/StudentsArabic/" + AccountID);
            return Student;
        }
        public async Task<SchoolImage> GetDTStudentImage(int AccountID)
        {
            var Image = await httpClient.GetFromJsonAsync<SchoolImage>(BaseUrl + "MerryLandStudentMaster/StudentImage/" + AccountID);
            return Image;
        }

        public async Task<string> GetNextNo(int BranchID)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/NextStudentCode?BranchID=" + BranchID);
            return code;
        }
        public async Task<string> GetSExistNo(int BranchID)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/ExistStudentCode?BranchID=" + BranchID);
            return code;
        }

        public async Task<string> GetParentNextNo(int BranchID, string Scode)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/NextParentCode?BranchID=" + BranchID + "&Scode=" + Scode); //AcademicYear = " + AcademicYear + " & BranchID = " + BranchID);
            return code;
        }

        public async Task<IEnumerable<SchoolDocument>> GetStudDocumentById(int AccountID)
        {
            var Document = await httpClient.GetFromJsonAsync<IEnumerable<SchoolDocument>>(BaseUrl + "MerryLandStudentMaster/DocumentByID/" + AccountID);
            return Document;
        }

        public async Task<SchoolDocument> GetDocumentByDocId(int DocID)
        {
            var File = await httpClient.GetFromJsonAsync<SchoolDocument>(BaseUrl + "MerryLandStudentMaster/DocumentByDocID/" + DocID);
            return File;
        }
        public async Task<SchoolDocument> GetValidationByDocType(string type)
        {
            SchoolDocument doc = await httpClient.GetFromJsonAsync<SchoolDocument>(BaseUrl + "Validation?Type=" + type);
            return doc;
        }
        public async Task<IEnumerable<SchoolAdditionalPayment>> GetAdditionalPayment(int AccountID)
        {
            var AdditionalPayment = await httpClient.GetFromJsonAsync<IEnumerable<SchoolAdditionalPayment>>(BaseUrl + "MerryLandStudentMaster/AdditionalPayment/" + AccountID);
            return AdditionalPayment;
        }
        public async Task<IEnumerable<SchoolAdditionalPayment>> GetAdditionalDiscount(int AccountID)
        {
            var AdditionalDiscount = await httpClient.GetFromJsonAsync<IEnumerable<SchoolAdditionalPayment>>(BaseUrl + "MerryLandStudentMaster/AdditionalDiscount/" + AccountID);
            return AdditionalDiscount;
        }
        public async Task<IEnumerable<SchoolFamilyDetail>> GetRelation(int AccountID)
        {
            var Relation = await httpClient.GetFromJsonAsync<IEnumerable<SchoolFamilyDetail>>(BaseUrl + "MerryLandStudentMaster/Relation/" + AccountID);
            return Relation;
        }
        public async Task<IEnumerable<SchoolStudentNote>> GetNotes(int AccountID)
        {
            var Notes = await httpClient.GetFromJsonAsync<IEnumerable<SchoolStudentNote>>(BaseUrl + "MerryLandStudentMaster/Notes/" + AccountID);
            return Notes;
        }

        public async Task<IEnumerable<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int BranchID)
        {
            var Statement = await httpClient.GetFromJsonAsync<IEnumerable<dtStudentStatement>>(BaseUrl + "MerryLandStudentMaster/StudentStatement?FromDate=" + FromDate + "&ToDate=" + ToDate + "&AccountID=" + AccountID + "&BranchID=" + BranchID);
            return Statement;
        }

        public async Task<IEnumerable<dtStudentRegister>> GetSiblingRegister(int ParentID, int BranchID, int AccountID,string academicYear)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "MerryLandStudentMaster/WithoutID?ParentID=" + ParentID + "&BranchID=" + BranchID + "&AccountID=" + AccountID + "&academicYear=" + academicYear);
        }

        public async Task<string> GetStaffID(int BranchID, string Code)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/StaffID?BranchID=" + BranchID + "&Code=" + Code);
            return code;
        }

        public async Task<IEnumerable<dtFeeStatus>> GetFeeStatus(int AccountID, string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtFeeStatus>>(BaseUrl + "MerryLandStudentMaster/GetFeeStatus?AccountID=" + AccountID + "&AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }


        //public async Task<HttpResponseMessage> SaveAdd(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/post", Student);
        //}

        //public async Task<HttpResponseMessage> SaveSibling(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/AddSibling", Student);
        //}

        //public async Task<HttpResponseMessage> SaveUpdate(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/updatedata", Student);
        //}

        //public async Task<HttpResponseMessage> UpdateStudent(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/UpdateStudent", Student);
        //}

        //public async Task<HttpResponseMessage> SaveImage(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/AddImage", Student);
        //}

        //public async Task<HttpResponseMessage> SaveUpdateImage(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/UpdateImage", Student);
        //}

        //public async Task<HttpResponseMessage> SaveNote(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/AddNote", Student);
        //}

        //public async Task<HttpResponseMessage> UpdateNote(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/UpdateNote", Student);
        //}

        //public async Task<HttpResponseMessage> DeleteNoteById(dtMasterStudent Note)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/DeleteNote", Note);
        //}

        //public async Task<HttpResponseMessage> SaveRelation(dtMasterStudent Relation)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/AddRelation", Relation);
        //}

        //public async Task<HttpResponseMessage> UpdateRelation(dtMasterStudent Relation)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/UpdateRelation", Relation);
        //}

        //public async Task<HttpResponseMessage> DeleteRelationByID(dtMasterStudent Relation)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/DeleteRelation", Relation);
        //}

        //public async Task<HttpResponseMessage> SaveDocument(dtMasterStudent Document)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/AddDocument", Document);
        //}
        //public async Task<HttpResponseMessage> UpdateDocument(dtMasterStudent Document)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/UpdateDocument", Document);
        //}
        //public async Task<HttpResponseMessage> DeleteDocumentByDocId(dtMasterStudent Document)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/DeleteDocument", Document);
        //}

        //public async Task<HttpResponseMessage> SaveParent(dtMasterStudent Parent)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/AddParent", Parent);
        //}


        public async Task<string> GetEnableTab(string Tab)
        {
            //return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>(BaseUrl + "DB/PLevel");
            var EnableTab = await httpClient.GetStringAsync(BaseUrl + "MerryLandStudentMaster/EnableTab?Tab=" + Tab);
            return EnableTab;
        }

        public async Task<string> GetExistStudent(string Scode, int BranchID)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/ExistImportStudentCode?Scode=" + Scode + "&BranchID=" + BranchID);
            return code;
        }

        public async Task<string> GetExistParentID(string Pcode, int BranchID)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/ExistParent?Pcode=" + Pcode + "&BranchID=" + BranchID);
            return code;
        }

        public async Task<HttpResponseMessage> ImportStudent(Accounts Data)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl + "MerryLandStudentMaster/ImportStudent", Data);
        }

        //public async Task<dtImportStudent> GetDTImportStudent(string Scode, int BranchID)
        //{
        //    var Student = await httpClient.GetFromJsonAsync<dtImportStudent>(BaseUrl + "StudentMaster/ImportStudent/" + Scode + "/" + BranchID);
        //    return Student;
        //}

        public async Task<string> GetTeacherName(string Class, string Division, int BranchID)
        {
            var Teacher = await httpClient.GetStringAsync(BaseUrl + "DB/GetTeacherName?Class=" + Class + "&Division=" + Division + "&BranchID=" + BranchID);
            return Teacher;
        }

        public async Task<string> GetAge(int AccountID)
        {
            var Age = await httpClient.GetStringAsync(BaseUrl + "MerryLandStudentMaster/StudentAge?AccountID=" + AccountID);
            return Age;
        }
    }
}
