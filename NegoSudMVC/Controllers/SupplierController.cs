using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegoSudMVC.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult TableList()
        {
            return View();
        }
    }
}
