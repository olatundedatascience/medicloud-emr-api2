using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class VisitType
    {
        public int Typeid { get; set; }
        public string Typename { get; set; }
        public DateTime Dateadded { get; set; }
    }
}
