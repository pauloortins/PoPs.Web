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
    }
}
