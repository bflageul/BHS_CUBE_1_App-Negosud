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
    public class LoginModel
    {
        public virtual User Users { get; set; }
        [Required] public string username { get; set; }
        [Required] public string hashpassword { get; set; }
        public bool rememberme { get; set; }

    }
}