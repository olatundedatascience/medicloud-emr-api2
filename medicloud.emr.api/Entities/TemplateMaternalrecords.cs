using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateMaternalrecords
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Mothersname { get; set; }
        public string Dob { get; set; }
        public string Registrationnumber { get; set; }
        public string Dateofadmission { get; set; }
        public string Eddbydate { get; set; }
        public string Antenatalscan { get; set; }
        public string Maternalproblem { get; set; }
        public string Relevantmaterialmedication { get; set; }
        public string Relevantfamilyhistory { get; set; }
        public string Nameofnurseormidwife { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
