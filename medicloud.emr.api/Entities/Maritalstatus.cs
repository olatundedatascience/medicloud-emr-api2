using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medicloud.emr.api.Entities
{
    public partial class Maritalstatus
    {
        public Maritalstatus()
        {
            Patient = new HashSet<Patient>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Maritalstatusid { get; set; }
        public string Maritalstatusname { get; set; }
        public DateTime? Dateadded { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
