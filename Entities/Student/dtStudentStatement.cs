﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class dtStudentStatement
    {
        [Key]
        public long Vid { get; set; }
        public long Veid { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Vno { get; set; }
        public string RefNo { get; set; }
        public string Vtype { get; set; }
        public string MainAccountName { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Class { get; set; }
        public string Division { get; set; }
        public string parentCode { get; set; }
        public string ParentName { get; set; }
        public string StudentStatus { get; set; }
        public string Description { get; set; }
        public string CommonNarration { get; set; }
        public string Descriptions { get; set; }
        public string Narration { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string RowType { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int? BankId { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }
        public int? OrderNo { get; set; }
        public int? AccountId { get; set; }
        public decimal Balance { get; set; }
    }
}
