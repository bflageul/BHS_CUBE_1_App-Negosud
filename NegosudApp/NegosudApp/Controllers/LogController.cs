using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NegosudApp.Models;
using NegosudApp.Migrations;
using Microsoft.AspNetCore.Identity;
using NegosudApp.PasswordHash;
using Microsoft.Data.SqlClient;

namespace NegosudApp.Controllers
{
   public class LogController : Controller
    {
        private readonly NegosudDbContext _context;
        private readonly IPwdHasher _pwdHasher;

        public LogController(
            NegosudDbContext context,
            PwdHasher pwdHasher)
        {
            _context = context;
            _pwdHasher = pwdHasher;
        }

        // Login method returning View
        public IActionResult Login()
        {
            return View("Error");
        }

        // Login test from controller 
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            string username = loginModel.username;
            string password = loginModel.hashpassword;
            bool logResult = _pwdHasher.Check(username, password);

            if (logResult is true)
            {
                return View("../Home/Logged");
            }
            else
            {
                return View("../Home/Register");
            }
        }


        //Logout fonction
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index");
        //}
    }
}