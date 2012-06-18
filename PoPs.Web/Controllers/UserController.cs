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
                    ModelState.AddModelError("", "Usuário ou Password inválido");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
