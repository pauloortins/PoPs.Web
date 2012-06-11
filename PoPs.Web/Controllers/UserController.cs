using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoPs.Web.Models;

namespace PoPs.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }
    }
}
