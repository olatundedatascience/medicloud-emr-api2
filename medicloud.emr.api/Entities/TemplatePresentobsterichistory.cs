using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplatePresentobsterichistory
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Datebleeding { get; set; }
        public string Lmp { get; set; }
        public string Edd { get; set; }
        public string Ega { get; set; }
        public string Radio1 { get; set; }
        public string Urinarysymptoms { get; set; }
        public string Radio2 { get; set; }
        public string Febrilicillness { get; set; }
        public string Pelvicpain { get; set; }
        public string Excessivevomiting { get; set; }
        public string Columns { get; set; }
        public string Columns1 { get; set; }
        public string Columns2 { get; set; }
        public string Columns3 { get; set; }
        public string Columns4 { get; set; }
        public string Otherrelevantsymptoms { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
