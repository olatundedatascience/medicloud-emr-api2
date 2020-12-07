using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateManagementchangesinthelast24hrs
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Am { get; set; }
        public string Pm { get; set; }
        public string Cxr { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
