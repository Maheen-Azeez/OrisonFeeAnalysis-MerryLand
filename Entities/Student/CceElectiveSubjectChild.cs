using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class CceElectiveSubjectChild
    {
        public int Etid { get; set; }
        public string Posted { get; set; }

        public int AccountID { get; set; }
        public string PrevClass { get; set; }
        public string Class { get; set; }
        public string StudentName { get; set; }

        public string Division { get; set; }
        public string StudentCode { get; set; }
        public int? BranchId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public double? Credit { get; set; }
        public string Academicyear { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Options { get; set; }
        public string Option1 { get; set; }

        public string Option2 { get; set; }
        public string Subjectbycomma { get; set; }


        public string Option3 { get; set; }

        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public int SubjectCount { get; set; }
    }
}
