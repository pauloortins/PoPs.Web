using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoPs.Web.Models;
using PoPs.Service;
using PoPs.Web.Infrastructure;

namespace PoPs.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private IAuthProvider authProvider;

        public UserController(IUserService userService, IAuthProvider authProvider)
        {
            this.userService = userService;
            this.authProvider = authProvider;
        }

        //
        // GET: /User/

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                userService.Create(user.ConvertToDomain());
                return View("Success");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(userLoginViewModel.Login, userLoginViewModel.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "'Login' ou 'Senha' inválido(a).");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forgot(UserForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                userService.SendNewPasswordToEmail(forgotPasswordViewModel.Email);
                return View("ForgotSuccess");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            authProvider.Signout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserChangePasswordViewModel changedPassword)
        {
            if (ModelState.IsValid)
            {
                userService.ChangePassword(HttpContext.User.Identity.Name, changedPassword.NewPassword);
                return View("PasswordChanged");
            }

            return View();
        }
    }
}
