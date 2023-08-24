using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Data.Login
{
    public class UserRights
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int? ProfileID { get; set; }
        public int BranchID { get; set; }
        public int KeywordID { get; set; }
        public string category { get; set; }
        public bool AllowOpen { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }
        public bool AccessDenied { get; set; }
        public string Keyword { get; set; }
        public string Module { get; set; }
    }
}
