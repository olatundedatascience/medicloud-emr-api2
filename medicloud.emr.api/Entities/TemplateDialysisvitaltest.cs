using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateDialysisvitaltest
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Pretreatmentdiagnoses { get; set; }
        public string Posttreatmentdiagnoses { get; set; }
        public string Indicationsfordialysis { get; set; }
        public string Pretreatmentweight { get; set; }
        public string Pretreatmentlabtestresult { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
