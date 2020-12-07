using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            BreakBlockSchedule = new HashSet<BreakBlockSchedule>();
            ProviderSchedule = new HashSet<ProviderSchedule>();
        }

        public int Appuserid { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Passwordhash { get; set; }
        public string Image { get; set; }
        public int? Locationid { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<BreakBlockSchedule> BreakBlockSchedule { get; set; }
        public virtual ICollection<ProviderSchedule> ProviderSchedule { get; set; }
    }
}
