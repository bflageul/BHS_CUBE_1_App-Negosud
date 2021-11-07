using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSudMVC.Models
{
    public class Supplier
    {
        public int Id { get;set }
        public int Address_Id { get;set }
        public string SupplierName { get;set }
        public string PhoneNumber { get;set }
    }
}
