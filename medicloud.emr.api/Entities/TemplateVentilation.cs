using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateVentilation
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Mode { get; set; }
        public string Pipandpeep { get; set; }
        public string Map { get; set; }
        public string Ti { get; set; }
        public string Ratedp { get; set; }
        public string Fioz { get; set; }
        public string Spoz { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
