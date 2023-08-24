using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalyis.Entities.General
{
    public class dtDashBoard
    {
        public int Count { get; set; }
        public Decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime ToDate { get; set; }

    }
}
