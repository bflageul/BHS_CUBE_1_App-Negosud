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
using System.Security.Cryptography;

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



        //// Login fonction
        //public IActionResult Login()
        //{
        //    return View("Error");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(string username, string password)
        //{
        //    var user = await _userManager.FindByNameAsync(username);

        //    if (user != null)
        //    {
        //        //sign in here
        //        var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

        //        if (signInResult.Succeeded)
        //        {
        //            //sign user here
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}


        //Logout fonction
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index");
        //}
    }
}