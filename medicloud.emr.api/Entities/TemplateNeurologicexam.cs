using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateNeurologicexam
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Fits { get; set; }
        public string Jittery { get; set; }
        public string Abnormalmovement { get; set; }
        public string Lethargic { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
