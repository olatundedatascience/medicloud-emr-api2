using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateDeliverydetails
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Modeofdelivery { get; set; }
        public string Presentation { get; set; }
        public string Maternalsedation { get; set; }
        public string Lscs { get; set; }
        public string Onsetoflabor { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
