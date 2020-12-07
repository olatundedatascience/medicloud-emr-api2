using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplatePlan
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Foodandideatoemphasize { get; set; }
        public string Foodstolimit { get; set; }
        public string Foodstoavoid { get; set; }
        public string Othernotes { get; set; }
        public string Handoutanddietsheetgive1 { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
