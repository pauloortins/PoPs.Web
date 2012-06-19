using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Repository.Repositories;
using PoPs.Domain;

namespace PoPs.Service
{
    public class UserService : IUserService
    {
        IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User GetById(int id)
        {
            return this.repository.GetById(id);
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
    }
}
