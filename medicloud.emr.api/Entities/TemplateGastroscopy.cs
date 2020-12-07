using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateGastroscopy
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Dateofbirth { get; set; }
        public string Hospitalnumber { get; set; }
        public string Endoscopist { get; set; }
        public string Endoscopenumber { get; set; }
        public string Indication { get; set; }
        public string Comorbidity { get; set; }
        public string Intubation { get; set; }
        public string Sedation { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
