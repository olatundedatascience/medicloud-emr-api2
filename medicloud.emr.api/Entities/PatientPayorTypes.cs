using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class PatientPayorTypes
    {
        public int Id { get; set; }
        public string Patientid { get; set; }
        public string Payor { get; set; }
        public string accountcategory { get; set; }
        public string plantype { get; set; }
        public string sponsor { get; set; }
    }
}
