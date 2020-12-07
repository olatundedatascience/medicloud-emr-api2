using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateAbdomen
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Distended { get; set; }
        public string Soft { get; set; }
        public string Firm { get; set; }
        public string Hyperemic { get; set; }
        public string Tender { get; set; }
        public string Hepatomegaly { get; set; }
        public string Splenomegaly { get; set; }
        public string Renomegaly { get; set; }
        public string Bowelsound { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
