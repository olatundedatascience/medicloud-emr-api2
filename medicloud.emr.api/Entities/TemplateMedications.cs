using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateMedications
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Asperanethesia { get; set; }
        public string Antiemeticprophylaxisasperorder { get; set; }
        public string Prophylacticantibioticprescribed { get; set; }
        public string Injectionofclexaneat2000 { get; set; }
        public string Columns { get; set; }
        public string Columns1 { get; set; }
        public string Applytedstockings { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
