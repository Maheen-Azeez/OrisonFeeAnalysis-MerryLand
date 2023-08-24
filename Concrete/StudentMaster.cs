using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract;
using OrisonFeeAnalysis.Entities.General;
using OrisonFeeAnalysis.Entities.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete
{
    public class StudentMaster : IStudentMaster
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        HttpClient httpClient = new HttpClient();
        public StudentMaster(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        public async Task<IEnumerable<dtStudentRegister>> GetStudentList(string AcademicYear, int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<dtStudentRegister>>(BaseUrl + "Bind/StudentList?AcademicYear=" + AcademicYear + "&BranchID=" + BranchID);
        }
        //public async Task<IEnumerable<MastDesignation>> BindComboBox(string type)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<MastDesignation>>(BaseUrl + "Bind?type=" + type);
        //}
        public async Task<IEnumerable<SchoolAcademicYear>> GetAcademicYear(int BranchID)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<SchoolAcademicYear>>(BaseUrl + "StudentMaster?BranchID=" + BranchID);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IEnumerable<SchoolClass>> GetClass(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "StudentMaster/Class?BranchID=" + BranchID);
        }
        public async Task<IEnumerable<SchoolClass>> GetDivision(int BranchID)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<SchoolClass>>(BaseUrl + "StudentMaster/Division?BranchID=" + BranchID);
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

        //public async Task<IEnumerable<HrtransportationMast>> GetBusDetails(int BranchID)
        //{
        //    return await httpClient.GetFromJsonAsync<IEnumerable<HrtransportationMast>>(BaseUrl + "DB/BusDetails?BranchID=" + BranchID);
        //}

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
            var Value = await httpClient.GetStringAsync(BaseUrl + "Bind/Setting?Category=" + Category);
            return Value;
        }








        public async Task<Accounts> GetDTAccount(int AccountID)
        {
            var Account = await httpClient.GetFromJsonAsync<Accounts>(BaseUrl + "StudentMaster/" + AccountID);
            return Account;
        }
        public async Task<SchoolStudent> GetDTStudent(int AccountID)
        {
            var Student = await httpClient.GetFromJsonAsync<SchoolStudent>(BaseUrl + "StudentMaster/Student/" + AccountID);
            return Student;
        }
        public async Task<SchoolStudentTran> GetDTStudentTrans(int AccountID, int BranchID, string AcademicYear)
        {
            var StudentTrans = await httpClient.GetFromJsonAsync<SchoolStudentTran>(BaseUrl + "StudentMaster/StudentTrans/" + AccountID + "/" + BranchID + "/" + AcademicYear);
            return StudentTrans;
        }
        public async Task<SchoolParentMaster> GetDTParent(int AccountID)
        {
            var Student = await httpClient.GetFromJsonAsync<SchoolParentMaster>(BaseUrl + "StudentMaster/Parent/" + AccountID);
            return Student;
        }
        //public async Task<SchoolStudentsArabic> GetDTStudentsArabic(int AccountID)
        //{
        //    var Student = await httpClient.GetFromJsonAsync<SchoolStudentsArabic>(BaseUrl + "StudentMaster/StudentsArabic/" + AccountID);
        //    return Student;
        //}
        //public async Task<SchoolImage> GetDTStudentImage(int AccountID)
        //{
        //    var Image = await httpClient.GetFromJsonAsync<SchoolImage>(BaseUrl + "StudentMaster/StudentImage/" + AccountID);
        //    return Image;
        //}

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

        //public async Task<IEnumerable<SchoolDocument>> GetStudDocumentById(int AccountID)
        //{
        //    var Document = await httpClient.GetFromJsonAsync<IEnumerable<SchoolDocument>>(BaseUrl + "StudentMaster/DocumentByID/" + AccountID);
        //    return Document;
        //}

        //public async Task<SchoolDocument> GetDocumentByDocId(int DocID)
        //{
        //    var File = await httpClient.GetFromJsonAsync<SchoolDocument>(BaseUrl + "StudentMaster/DocumentByDocID/" + DocID);
        //    return File;
        //}
        //public async Task<SchoolDocument> GetValidationByDocType(string type)
        //{
        //    SchoolDocument doc = await httpClient.GetFromJsonAsync<SchoolDocument>(BaseUrl + "Validation?Type=" + type);
        //    return doc;
        //}
        //public async Task<IEnumerable<SchoolAdditionalPayment>> GetAdditionalPayment(int AccountID)
        //{
        //    var AdditionalPayment = await httpClient.GetFromJsonAsync<IEnumerable<SchoolAdditionalPayment>>(BaseUrl + "StudentMaster/AdditionalPayment/" + AccountID);
        //    return AdditionalPayment;
        //}
        //public async Task<IEnumerable<SchoolAdditionalPayment>> GetAdditionalDiscount(int AccountID)
        //{
        //    var AdditionalDiscount = await httpClient.GetFromJsonAsync<IEnumerable<SchoolAdditionalPayment>>(BaseUrl + "StudentMaster/AdditionalDiscount/" + AccountID);
        //    return AdditionalDiscount;
        //}
        //public async Task<IEnumerable<SchoolFamilyDetail>> GetRelation(int AccountID)
        //{
        //    var Relation = await httpClient.GetFromJsonAsync<IEnumerable<SchoolFamilyDetail>>(BaseUrl + "StudentMaster/Relation/" + AccountID);
        //    return Relation;
        //}
        //public async Task<IEnumerable<SchoolStudentNote>> GetNotes(int AccountID)
        //{
        //    var Notes = await httpClient.GetFromJsonAsync<IEnumerable<SchoolStudentNote>>(BaseUrl + "StudentMaster/Notes/" + AccountID);
        //    return Notes;
        //}

        //public async Task<IEnumerable<dtStudentStatement>> GetStatement(string FromDate, string ToDate, int AccountID, int BranchID)
        //{
        //    var Statement = await httpClient.GetFromJsonAsync<IEnumerable<dtStudentStatement>>(BaseUrl + "StudentMaster/StudentStatement?FromDate=" + FromDate + "&ToDate=" + ToDate + "&AccountID=" + AccountID + "&BranchID=" + BranchID);
        //    return Statement;
        //}

        public async Task<string> GetStaffID(int BranchID, string Code)
        {
            var code = await httpClient.GetStringAsync(BaseUrl + "DB/StaffID?BranchID=" + BranchID + "&Code=" + Code);
            return code;
        }




        //public async Task<HttpResponseMessage> SaveAdd(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/post", Student);
        //}

        //public async Task<HttpResponseMessage> SaveSibling(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/AddSibling", Student);
        //}

        //public async Task<HttpResponseMessage> SaveUpdate(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/updatedata", Student);
        //}

        //public async Task<HttpResponseMessage> UpdateStudent(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/UpdateStudent", Student);
        //}

        //public async Task<HttpResponseMessage> SaveImage(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/AddImage", Student);
        //}

        //public async Task<HttpResponseMessage> SaveUpdateImage(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/UpdateImage", Student);
        //}

        //public async Task<HttpResponseMessage> SaveNote(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/AddNote", Student);
        //}

        //public async Task<HttpResponseMessage> UpdateNote(dtMasterStudent Student)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/UpdateNote", Student);
        //}

        //public async Task<HttpResponseMessage> DeleteNoteById(dtMasterStudent Note)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/DeleteNote", Note);
        //}

        //public async Task<HttpResponseMessage> SaveRelation(dtMasterStudent Relation)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/AddRelation", Relation);
        //}

        //public async Task<HttpResponseMessage> UpdateRelation(dtMasterStudent Relation)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/UpdateRelation", Relation);
        //}

        //public async Task<HttpResponseMessage> DeleteRelationByID(dtMasterStudent Relation)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/DeleteRelation", Relation);
        //}

        //public async Task<HttpResponseMessage> SaveDocument(dtMasterStudent Document)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/AddDocument", Document);
        //}
        //public async Task<HttpResponseMessage> UpdateDocument(dtMasterStudent Document)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/UpdateDocument", Document);
        //}
        //public async Task<HttpResponseMessage> DeleteDocumentByDocId(dtMasterStudent Document)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/DeleteDocument", Document);
        //}

        //public async Task<HttpResponseMessage> SaveParent(dtMasterStudent Parent)
        //{
        //    return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/AddParent", Parent);
        //}


        public async Task<string> GetEnableTab(string Tab)
        {
            //return await httpClient.GetFromJsonAsync<IEnumerable<Accounts>>(BaseUrl + "DB/PLevel");
            var EnableTab = await httpClient.GetStringAsync(BaseUrl + "StudentMaster/EnableTab?Tab=" + Tab);
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
            return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/ImportStudent", Data);
        }

        //public async Task<dtImportStudent> GetDTImportStudent(string Scode, int BranchID)
        //{
        //    var Student = await httpClient.GetFromJsonAsync<dtImportStudent>(BaseUrl + "StudentMaster/ImportStudent/" + Scode + "/"+ BranchID);
        //    return Student;
        //}

        public async Task<string> GetTeacherName(string Class, string Division, int BranchID)
        {
            var Teacher = await httpClient.GetStringAsync(BaseUrl + "DB/GetTeacherName?Class=" + Class + "&Division=" + Division + "&BranchID=" + BranchID);
            return Teacher;
        }

        public async Task<string> GetAge(int AccountID)
        {
            var Age = await httpClient.GetStringAsync(BaseUrl + "StudentMaster/StudentAge?AccountID=" + AccountID);
            return Age;
        }

        public async Task<HttpResponseMessage> Update(DtUpdate dt)
        {
            return await httpClient.PostAsJsonAsync(BaseUrl + "StudentMaster/DtUpdate", dt);

        }
    }
}
