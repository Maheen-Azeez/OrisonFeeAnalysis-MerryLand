using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Financial.Main
{
    public class VoucherDocuments
    {
        [Key]
        public int ID { get; set; }
        public int VID { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }

    }
}
