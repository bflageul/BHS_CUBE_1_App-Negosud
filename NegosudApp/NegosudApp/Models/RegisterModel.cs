using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//using System.ComponentModel.DataAnnotations;
//using System.Text;
//using System.Text.Encodings.Web;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.Extensions.Logging;

namespace NegosudApp.Models
{
    public class RegisterModel
    {
        internal readonly object addresses;

        public virtual User Users { get; set; }
        [Required] public string username { get; set; }
        [Required] public string firstname { get; set; }
        [Required] public string lastname { get; set; }
        [Required] public string hashpassword { get; set; }
        [Compare("hashpassword", ErrorMessage = "Le mot de passe ne correspond pas à la confirmation !")] public string confirmpassword { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public string streetnumber { get; set; }
        public string waytype { get; set; }
        [Required] public string streetname { get; set; }
        [Required] public string postalcode { get; set; }
        [Required] public string city { get; set; }
        [Required] public string country { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        [Required] public string email { get; set; }
        



        //        //private readonly SignInManager<IdentityUser> _signInManager;
        //        //private readonly UserManager<IdentityUser> _userManager;
        //        //private readonly ILogger<RegisterModel> _logger;
        //        //private readonly IEmailSender _emailSender;

        //        //public RegisterModel(
        //        //    UserManager<IdentityUser> userManager,
        //        //    SignInManager<IdentityUser> signInManager,            
        //        //    ILogger<RegisterModel> logger,
        //        //    IEmailSender emailSender)
        //        //{
        //        //    _userManager = userManager;
        //        //    _signInManager = signInManager;
        //        //    _logger = logger;
        //        //    _emailSender = emailSender;
        //        //}

        //        //[BindProperty]
        //        //public InputModel Input { get; set; }

        //        //public string ReturnUrl { get; set; }

        //        //public IList<AuthenticationScheme> ExternalLogins { get; set; }

        //        //public class InputModel
        //        //{
        //            [Required]
        //            [Display(Name = "Nom d'utilisateur")]
        //            public string Username { get; set; }

        //            [Required]
        //            [Display(Name = "Prénom")]
        //            public string Firstname { get; set; }

        //            [Required]
        //            [Display(Name = "Nom")]
        //            public string Lastname { get; set; }

        //            [Required]
        //            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //            [DataType(DataType.Password)]
        //            [Display(Name = "Choisissez un mot de passe")]
        //            public string HashPassword { get; set; }

        //            [DataType(DataType.Password)]
        //            [Display(Name = "Confirmer votre mot de passe")]
        //            [Compare("HashPassword", ErrorMessage = "le mot de passe ne correspond pas à la confirmation !")]
        //            public string ConfirmPassword { get; set; }

        //            [Display(Name = "Numéro de la voie")]
        //            public string StreetNumber { get; set; }

        //            [Display(Name = "Type de voie")]
        //            public string WayType { get; set; }

        //            [Required]
        //            [Display(Name = "Nom de la voie")]
        //            public string StreetName { get; set; }

        //            [Required]
        //            [Display(Name = "Code postal")]
        //            public string PostalCode { get; set; }

        //            [Required]
        //            [Display(Name = "Ville")]
        //            public string City { get; set; }

        //            [Required]
        //            [Display(Name = "Pays")]
        //            public string Country { get; set; }

        //            [Required]
        //            [EmailAddress]
        //            [Display(Name = "Email")]
        //            public string Email { get; set; }

        //        //}

        //        //public async Task OnGetAsync(string returnUrl = null)
        //        //{
        //        //    ReturnUrl = returnUrl;
        //        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //        //}

        //        //    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //        //    {
        //        //        returnUrl ??= Url.Content("~/");
        //        //        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //        //        if (ModelState.IsValid)
        //        //        {
        //        //            var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };

        //        //            //Modify the Input.Password with Input.HashPassword
        //        //            var result = await _userManager.CreateAsync(user, Input.HashPassword);
        //        //            if (result.Succeeded)
        //        //            {
        //        //                _logger.LogInformation("User created a new account with password.");

        //        //                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //        //                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //        //                var callbackUrl = Url.Page(
        //        //                    "/Account/ConfirmEmail",
        //        //                    pageHandler: null,
        //        //                    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
        //        //                    protocol: Request.Scheme);

        //        //                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //        //                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //        //                if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //        //                {
        //        //                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
        //        //                }
        //        //                else
        //        //                {
        //        //                    await _signInManager.SignInAsync(user, isPersistent: false);
        //        //                    return LocalRedirect(returnUrl);
        //        //                }
        //        //            }
        //        //            foreach (var error in result.Errors)
        //        //            {
        //        //                ModelState.AddModelError(string.Empty, error.Description);
        //        //            }
        //        //        }

        //        //        // If we got this far, something failed, redisplay form
        //        //        return Page();
        //        //    }
    }
}