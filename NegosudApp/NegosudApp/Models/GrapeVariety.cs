using System;
using System.Collections.Generic;

#nullable disable

namespace NegosudApp.Models
{
    public partial class GrapeVariety
    {
        public GrapeVariety()
        {
            GrapeRates = new HashSet<GrapeRate>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public string GrapeName { get; set; }

        public virtual ICollection<GrapeRate> GrapeRates { get; set; }
    }
}
