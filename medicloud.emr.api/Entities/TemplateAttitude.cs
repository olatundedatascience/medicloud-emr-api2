using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateAttitude
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Flexion { get; set; }
        public string Partialflexion { get; set; }
        public string Extension { get; set; }
        public string Suck { get; set; }
        public string Grasp { get; set; }
        public string Mororeflex { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
