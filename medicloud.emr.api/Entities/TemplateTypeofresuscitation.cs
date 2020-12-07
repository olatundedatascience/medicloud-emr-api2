using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateTypeofresuscitation
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Suction { get; set; }
        public string Tactilestimulation { get; set; }
        public string Bagmask { get; set; }
        public string Intubation { get; set; }
        public string Umbilicalcatheterization { get; set; }
        public string Drugs { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
