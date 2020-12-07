using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateAnthpropometry
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Weight { get; set; }
        public string Sga { get; set; }
        public string Aga { get; set; }
        public string Lga { get; set; }
        public string Lengthcm { get; set; }
        public string Headcircumferencecm { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
