using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateGeneralapearances
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Sleeping { get; set; }
        public string Pink { get; set; }
        public string Blue { get; set; }
        public string Pale { get; set; }
        public string Jaundiced { get; set; }
        public string Conscious { get; set; }
        public string Hsiii { get; set; }
        public string Murmur { get; set; }
        public string Mbp { get; set; }
        public string Hr { get; set; }
        public string Rr { get; set; }
        public string Ae { get; set; }
        public string Addedsounds { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
