using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using PoPs.Infrasctructure;
using PoPs.Domain;
using PoPs.Service;

namespace PoPs.Web.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {
        private IUserService userService;

        public FormsAuthProvider(IUserService userService)
        {
            this.userService = userService;
        }

        public bool Authenticate(string username, string password)
        {
            bool isAuthenticate = userService.Login(username, PasswordHash.GetMD5Hash(password));

            if (isAuthenticate)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return isAuthenticate;
        }

        public void Signout()
        {
            FormsAuthentication.SignOut();
        }
    }
}