using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplatePastobsterichistory
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Gravidity { get; set; }
        public string Para { get; set; }
        public string Alive { get; set; }
        public string Miscarriage { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
