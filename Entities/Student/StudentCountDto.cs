using System.Collections.Generic;
using System.Dynamic;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class StudentCountDto
    {
        public int Excemption { get; set; }
        public int NewStudents { get; set; }
        public int Total { get; set; }
        public int Reregistration { get; set; }
    }
}
