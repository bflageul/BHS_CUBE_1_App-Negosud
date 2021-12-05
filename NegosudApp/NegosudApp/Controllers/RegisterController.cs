using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NegosudApp.Models;
using NegosudApp.Data;
using NegosudApp.PasswordHash;

namespace NegosudApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly NegosudDbContext _context;
        private PwdHasher _pwdHasher;

        public RegisterController(
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
        {
            User user = new User()
            {
                Username = registerModel.username,
                Firstname = registerModel.firstname,
                Lastname = registerModel.lastname,
                HashPassword = _pwdHasher.Hash(registerModel.hashpassword)
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

            Client client = new Client()
            {
                Address = address,
                Users = user,
                Email = registerModel.email,
                AddressId = address.Id,
                UsersId = user.Id
            };

            _context.Clients.Add(client);
            _context.Users.Add(user);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return View("../Home/Registered");
        }

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