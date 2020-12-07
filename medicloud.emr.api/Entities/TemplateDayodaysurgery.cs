using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateDayodaysurgery
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Bedrest { get; set; }
        public string Monitorvitalsigns { get; set; }
        public string Monitorpainscore { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
