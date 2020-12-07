using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateResult
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Result { get; set; }
        public string Ppr { get; set; }
        public string Qrs { get; set; }
        public string Qtqtc { get; set; }
        public string Pqrst { get; set; }
        public string Rvssv1 { get; set; }
        public string Rvssv2 { get; set; }
        public string Rv6sv2 { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
