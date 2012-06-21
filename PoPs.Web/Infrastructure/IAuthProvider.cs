using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoPs.Web.Infrastructure
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);

        void Signout();
    }
}