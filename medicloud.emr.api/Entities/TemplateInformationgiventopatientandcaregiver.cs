using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateInformationgiventopatientandcaregiver
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Continuingcare { get; set; }
        public string Medication { get; set; }
        public string Diet { get; set; }
        public string Specialtreatmentandcareanduseofequipment { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
