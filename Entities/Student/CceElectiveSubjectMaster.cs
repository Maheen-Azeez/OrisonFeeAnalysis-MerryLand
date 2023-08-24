using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class CceElectiveSubjectMaster
    {
        public int Eid { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public string Arab { get; set; }
        public string AcademicYear { get; set; }
        public string Combo { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int? Credit { get; set; }
        public int? BranchId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}
