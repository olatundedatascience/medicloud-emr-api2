using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateFluidfeeds
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Fluids { get; set; }
        public string Types { get; set; }
        public string Feeds { get; set; }
        public string Typevia { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
