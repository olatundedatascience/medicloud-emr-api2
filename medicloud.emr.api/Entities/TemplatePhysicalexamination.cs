using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplatePhysicalexamination
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Linesdatedlines { get; set; }
        public string Uac { get; set; }
        public string Uvc { get; set; }
        public string Textfield { get; set; }
        public string Longlines { get; set; }
        public string Others { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
