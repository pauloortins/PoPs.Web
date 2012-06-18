using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private EFContext context;

        public UserRepository(EFContext context)
        {
            this.context = context;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }
    }
}
