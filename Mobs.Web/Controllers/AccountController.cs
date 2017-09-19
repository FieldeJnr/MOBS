using Mobs.Logic.Providers;
using Mobs.Models.User;
using Mobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mobs.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // perform a login????

                var err = UserProvider.ValidateUser(model.EmailAddress, model.Password);
                if (err != null ) {
                    switch (err.ErrorCode)
                    {
                 
                        case Logic.MobsErrorEnum.DataNotFound:
                            ModelState.AddModelError("EmailAddress", "No user found please register in order to continue.");
                            break;
                        case Logic.MobsErrorEnum.InvalidPassword:
                            ModelState.AddModelError("Password", "Invalid Password.");
                            break;
                        default:
                            ModelState.AddModelError(string.Empty, err.ToString());
                            break;
                    }
                    return View(model);
                }

                var authTicket = new FormsAuthenticationTicket(1, model.EmailAddress, DateTime.Now, DateTime.Now.AddMonths(1), model.RememberMe, string.Empty);
                var cookieContent = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContent)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath
                };

                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.Compare(model.EmailAddress, model.ConfirmEmailAddress, true) != 0)
                {
                    ModelState.AddModelError(string.Empty, "Email addresses do not match");
                    return View(model);
                }

                if (string.Compare(model.Password, model.ConfirmPassword,false) != 0)
                {
                    ModelState.AddModelError(string.Empty, "Passwords do not match");
                    return View(model);
                }

                var err = UserProvider.Create(new UserModel {EmailAddress = model.EmailAddress,FullName = model.FullName,Password=model .Password });
                if (err != null)
                {
                    switch (err.ErrorCode)
                    {       

                        case Logic.MobsErrorEnum.DataNotFound:
                            ModelState.AddModelError("EmailAddress", "That email is already in use by another user.");
                            break;
                        default:
                            ModelState.AddModelError(string.Empty, err.ToString());
                            break;
                    }
                    return View();
                }

                return RedirectToAction( "Login","Home");
            }
            return View();
        }
    }
}