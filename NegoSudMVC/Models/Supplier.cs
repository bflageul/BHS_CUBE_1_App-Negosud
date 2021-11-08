using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSudMVC.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int Address_Id { get; set; }
        public string SocialReason { get; set; }
        public string SIRET { get; set; }
        public string APE_NAF { get; set; }
        public string TVA { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
