using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Service
{
    public interface IUserService
    {
        void Create(User user);

        bool Login(string username, string password);

        User FindByLogin(string login);

        User FindByEmail(string email);

        void SendNewPasswordToEmail(string email);

        void Update(User user);

        void ChangePassword(string userLogin, string newPassword);
    }
}
