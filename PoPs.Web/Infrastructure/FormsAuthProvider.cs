using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using PoPs.Infrasctructure;

namespace PoPs.Web.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool isAuthenticate = Membership.ValidateUser(username, PasswordHash.GetMD5Hash(password));

            if (isAuthenticate)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return isAuthenticate;
        }
    }
}