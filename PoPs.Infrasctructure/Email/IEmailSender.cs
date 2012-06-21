using System;
using System.Collections.Generic;
using System.Text;
using PoPs.Domain;

namespace PoPs.Infrasctructure
{
    public interface IEmailSender
    {
        void SendNewPassword(string email, string newPassword);
    }
}
