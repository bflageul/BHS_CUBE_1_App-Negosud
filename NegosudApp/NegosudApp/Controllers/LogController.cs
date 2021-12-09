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

//Login test from controller (!! some fonctions should move to PwdHasher!!)
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.Where(b => b.Username == username).FirstOrDefault();

            byte[] stockedKey = user.HashPassword;

            byte[] stockedSalt = new byte[16];
            Array.Copy(stockedKey, 2, stockedSalt, 0, 16);

            Rfc2898DeriveBytes algorithm = new(
              password,
              stockedSalt,
              10000,  //Options.Iterations,              
              HashAlgorithmName.SHA512);

            byte[] hashsalt = algorithm.GetBytes(16);
            byte[] hashpass = algorithm.GetBytes(20);

            byte[] keyToCheck = new byte[36];
            Array.Copy(hashsalt, 0, keyToCheck, 0, 16);
            Array.Copy(hashpass, 0, keyToCheck, 16, 20);

            if (keyToCheck == stockedKey)
            {
                return RedirectToAction("Error");
            }
            else
            {
                return RedirectToAction("Registered");
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}