using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class Maritalstatus
    {
        public Maritalstatus()
        {
            Patient = new HashSet<Patient>();
        }

        public int Maritalstatusid { get; set; }
        public string Maritalstatusname { get; set; }
        public DateTime? Dateadded { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
