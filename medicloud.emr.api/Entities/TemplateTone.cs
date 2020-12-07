using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateTone
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Normal { get; set; }
        public string Hypertonia { get; set; }
        public string Floppy { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
