﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Entities.Student
{
    public class MastDesignation
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public bool? VDefault { get; set; }
    }
}
