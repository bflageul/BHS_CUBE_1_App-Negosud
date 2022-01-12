﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using NegosudApp.Models;
using NegosudApp.Migrations;
using NegosudApp.PasswordHash;

namespace NegosudApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly NegosudDbContext _context;
        private readonly PwdHasher _pwdHasher;

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

        [HttpPost("register")]
        public IActionResult Register(RegisterModel registerModel)
        {
            User user = new()
            {
                Username = registerModel.username,
                Firstname = registerModel.firstname,
                Lastname = registerModel.lastname,
                HashPassword = _pwdHasher.Hash(registerModel.hashpassword)
            };

            Address address = new()
            {
                StreetNumber = registerModel.streetnumber,
                WayType = registerModel.waytype,
                StreetName = registerModel.streetname,
                PostalCode = registerModel.postalcode,
                City = registerModel.city,
                Country = registerModel.country
            };

            Client client = new()
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
    }
}
