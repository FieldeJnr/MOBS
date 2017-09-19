using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mobs.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "You must enter a email address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "You must enter a password")]
        public string Password { get; set; }
        public bool RememberMe { get; internal set; }
    }

    public class RegisterModel : LoginModel
    {
        [Required(ErrorMessage = "You must confirm your email address")]
        [Compare("EmailAddress", ErrorMessage = "Emails must match")]

        public string ConfirmEmailAddress { get; set; }
        [Required(ErrorMessage = "You must confirm your password")]
        [Compare("Password",ErrorMessage ="passwords must match")]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "You must enter your full name")]
        [MaxLength(20,ErrorMessage ="Please shorten your name to 20 charecters")]
        public string FullName { get; set; }
    }
}
