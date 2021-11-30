using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NegosudApp.Models;
using NegosudApp.Data;

namespace NegosudApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly NegosudDbContext context;
        public RegisterController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


//Register fonction
        //public IActionResult Register()
        //{
        //    return View("../Home/Registered");
        //}

        [HttpPost]
        public IActionResult Register(string streetname, string postalcode, string city, string country)
        {
            
            Address address = new Address()
            {
                StreetName = streetname,
                PostalCode = postalcode,
                City = city,
                Country = country
            };
            context.Addresses.Add(address);
            context.SaveChanges();
            return View("../Home/Registered");
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(string username, string password)
        //{
        //    var user = new IdentityUser
        //    {
        //        UserName = username,
        //        Email = ""
        //    };

        //    var result = await _userManager.CreateAsync(user);

        //    if(result.Succeeded)
        //    {
        //        //sign user here
        //    }

        //    return View("../Home/Registered");
        //}


        // Login fonction
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                //sign in here
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    //sign user here
                    return RedirectToAction("Index");                    
                }
            }

            return RedirectToAction("Index");
        }

//Logout fonction
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}