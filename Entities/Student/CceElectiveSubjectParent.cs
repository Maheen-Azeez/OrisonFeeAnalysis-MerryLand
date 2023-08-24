using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class CceElectiveSubjectParent
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public decimal Fine { get; set; }
        public decimal Revaluation { get; set; }
        public decimal TotalAmount { get; set; }

        public int Idnew { get; set; }
    }
}
