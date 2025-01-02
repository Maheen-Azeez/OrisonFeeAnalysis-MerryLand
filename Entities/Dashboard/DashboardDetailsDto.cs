using OrisonFeeAnalyis.Entities.General;
using System.Collections.Generic;

namespace OrisonFeeAnalysis.Entities.Dashboard
{
    public class DashboardDetailsDto
    {
        public IList<dtDashBoard> DashBoardData { get; set; }
        public int Count { get; set; }

    }
}
