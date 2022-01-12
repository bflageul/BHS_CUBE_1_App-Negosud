using System;
using System.Collections.Generic;

#nullable disable

namespace NegosudApp.Models
{
    public partial class Alcohol
    {
        public Alcohol()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Range { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
