using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class TemplateColonoscopy
    {
        public int Id { get; set; }
        public int? Accountid { get; set; }
        public int? Locationid { get; set; }
        public string Patientid { get; set; }
        public string Dateofprcedure { get; set; }
        public string Endoscopist { get; set; }
        public string Colonoscopenumber { get; set; }
        public string Indication { get; set; }
        public string Bowelpreparation { get; set; }
        public string Quantityofbowelpreparation { get; set; }
        public string Sedation { get; set; }
        public string Extentofintubation1 { get; set; }
        public string Textarea { get; set; }
        public string Report { get; set; }
        public string Caecum { get; set; }
        public string Ascendingcolon { get; set; }
        public string Transversecolon { get; set; }
        public string Descendingcolon { get; set; }
        public string Symoidcolon { get; set; }
        public string Rectum { get; set; }
        public string Analcanalonretroflexion { get; set; }
        public string Biopsies { get; set; }
        public string Diagnosis { get; set; }
        public string Treatmentandoutcome { get; set; }
        public DateTime? Dateadded { get; set; }
    }
}
