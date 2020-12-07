using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateTestspecimen
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Fbc { get; set; }
        public string Ptnr12goalsinrifonwatarin { get; set; }
        public string Eucrifindicatedclinically { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
