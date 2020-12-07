using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateJaundice
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Jaundice { get; set; }
        public string Lastsbtotal { get; set; }
        public string Conj { get; set; }
        public string Phototherapy { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
