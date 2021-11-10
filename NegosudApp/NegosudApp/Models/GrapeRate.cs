using System;
using System.Collections.Generic;

#nullable disable

namespace NegosudApp.Models
{
    public partial class GrapeRate
    {
        public int ProductId { get; set; }
        public int GrapeVarietyId { get; set; }
        public int? Rate { get; set; }

        public virtual GrapeVariety GrapeVariety { get; set; }
        public virtual Product Product { get; set; }
    }
}
