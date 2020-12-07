using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateMother
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Health { get; set; }
        public string Causeofdeath { get; set; }
        public string Status { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
