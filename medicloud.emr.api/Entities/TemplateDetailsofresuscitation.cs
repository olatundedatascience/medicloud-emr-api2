using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateDetailsofresuscitation
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Textfield { get; set; }
        public string Nameofmedicalstaff { get; set; }
        public string Columns { get; set; }
        public string Signatureofmedicalstaff { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
