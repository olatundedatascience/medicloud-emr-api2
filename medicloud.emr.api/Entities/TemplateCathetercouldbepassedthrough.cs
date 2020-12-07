using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateCathetercouldbepassedthrough
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string L { get; set; }
        public string R { get; set; }
        public string Columns { get; set; }
        public string Columns1 { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
