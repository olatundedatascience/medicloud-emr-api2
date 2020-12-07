using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateMedicationanddressings
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Obtained { get; set; }
        public string Instructiongiven { get; set; }
        public string Informationonwheretoobtainfurthersupply { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
