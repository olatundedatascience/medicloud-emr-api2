using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateTeaching
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Discusspainmanagementpainscaleandsideeffect { get; set; }
        public string Teachankleexercise { get; set; }
        public string Columns { get; set; }
        public string Explaintreatment { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
