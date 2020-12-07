using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace medicloud.emr.api.Entities
{
    public partial class BreakBlockSchedule
    {
        [Key]
        public int Blockid { get; set; }
        public string Blockname { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public string Days { get; set; }
        public string Adjuster { get; set; }
        public bool Iscurrent { get; set; }
        public DateTime Dateadded { get; set; }
        public int? Locationid { get; set; }
        public int? Provid { get; set; }

        public virtual Location Location { get; set; }
        public virtual ApplicationUser Prov { get; set; }
    }
}
