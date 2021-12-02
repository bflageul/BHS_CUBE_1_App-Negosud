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
        private readonly NegosudDbContext _context;
        public RegisterController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            NegosudDbContext context) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        //private readonly NegosudDbContext _context;
        //public RegisterController(NegosudDbContext context)
        //{
        //    _context = context;
        //}

//Register fonction
        //public IActionResult Register()
        //{
        //    return View("../Home/Registered");
        //}

        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
            //string streetnumber, 
            //string waytype, 
            //string streetname, 
            //string postalcode,
            //string city,
            //string country, 
            //string username, 
            //string firstname, 
            //string lastname, 
            //byte[] hashpassword,
            //byte[] confirmpassword)
        {

            byte[] ConfirmPassword = registerModel.confirmpassword;

            Client client = new Client()
            {
                Email = registerModel.email
            };

            User user = new User()
            {
                Username = registerModel.username,
                Firstname = registerModel.firstname,
                Lastname = registerModel.lastname,
                HashPassword = registerModel.hashpassword
            };

            Address address = new Address()
            {
                StreetNumber = registerModel.streetnumber,
                WayType = registerModel.waytype,
                StreetName = registerModel.streetname,
                PostalCode = registerModel.postalcode,
                City = registerModel.city,
                Country = registerModel.country
            };

            //_context.Clients.Add(client);
            _context.Users.Add(user);
            _context.Addresses.Add(address);
            _context.SaveChanges();
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