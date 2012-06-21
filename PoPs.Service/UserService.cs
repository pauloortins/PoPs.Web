using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Repository.Repositories;
using PoPs.Domain;
using PoPs.Infrasctructure;
using System.Transactions;

namespace PoPs.Service
{
    public class UserService : IUserService
    {
        IUserRepository repository;
        IEmailSender emailSender;

        public UserService(IUserRepository repository, IEmailSender emailSender)
        {
            this.repository = repository;
            this.emailSender = emailSender;
        }

        public void Create(User user)
        {
            repository.Create(user);
        }

        public bool Login(string login, string password)
        {
            return repository.GetAll().Where(x => x.Login.Equals(login) && x.Password.Equals(password)).Count() > 0;
        }

        public User FindByLogin(string login)
        {
            if (repository.GetAll().Where(x => x.Login.Equals(login)).Count() != 0)
            {
                return repository.GetAll().First(x => x.Login.Equals(login));
            }
            else
            {
                return null;
            }
        }

        public User FindByEmail(string email)
        {
            if (repository.GetAll().Where(x => x.Email.Equals(email)).Count() != 0)
            {
                return repository.GetAll().First(x => x.Email.Equals(email));
            }
            else
            {
                return null;
            }
        }

        public void SendNewPasswordToEmail(string email)
        {
            var newPassword = PasswordHash.GenerateNewPassword(DateTime.Now);

            User user = FindByEmail(email);
            user.Password = PasswordHash.GetMD5Hash(newPassword);

            using (TransactionScope scope = new TransactionScope())
            {
                Update(user);
                emailSender.SendNewPassword(user.Email, newPassword);
                scope.Complete();
            }
        }

        public void Update(User user)
        {
            repository.Update(user);
        }


        public void ChangePassword(string userLogin, string newPassword)
        {
            User user = FindByLogin(userLogin);
            user.Password = PasswordHash.GetMD5Hash(newPassword);
            Update(user);
        }
    }
}
