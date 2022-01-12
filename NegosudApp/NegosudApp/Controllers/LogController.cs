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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly NegosudDbContext _context;
        private readonly PwdHasher _pwdHasher;

        public LogController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            NegosudDbContext context,
            PwdHasher pwdHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _pwdHasher = pwdHasher;
        }


// Login fonction
        public IActionResult Login()
        {
            return View("Error");
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(string username, string password)
        //{
        //    string ConStr = _context.
        //    SqlCommand cmd = new SqlCommand("Select count(*) from Register where Username= @Username", NegosudConStr);
        //    }







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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}