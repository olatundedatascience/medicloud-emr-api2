using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplatePatientdetail
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Mothersbloodgroup { get; set; }
        public string Indicationforebt { get; set; }
        public string Babysbloodgroup { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
