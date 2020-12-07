using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateOtherfluids
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Dopamine { get; set; }
        public string Dobutamine { get; set; }
        public string Morphin { get; set; }
        public string Midazolam { get; set; }
        public string Insulin { get; set; }
        public string Bloodsugarrange { get; set; }
        public string Totalfluidsandfeeds { get; set; }
        public string Totalcalories { get; set; }
        public string Gainandlossof { get; set; }
        public string Bo { get; set; }
        public string Aspirate { get; set; }
        public string Vomit { get; set; }
        public string Urineoutput { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
