using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Financial.Main
{
    public class AccountList
    {
       public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public int ID { get; set; } 
        public string AccCategory { get; set; }
        public string AccountGroup { get; set; }
        public string SubGroup { get; set; }
        public int  VoucherEntry { get; set; }
        public string    GroupType { get; set; }
        public int  IsDefault { get; set; }
    }
}
