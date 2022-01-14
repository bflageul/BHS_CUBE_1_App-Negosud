using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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