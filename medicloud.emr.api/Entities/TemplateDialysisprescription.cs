using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateDialysisprescription
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Treatmentduration { get; set; }
        public string Bloodflowrate { get; set; }
        public string Dialysisflowrate { get; set; }
        public string Anticoagulation { get; set; }
        public string Ultafiltration { get; set; }
        public string Dialysisaccessused { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
