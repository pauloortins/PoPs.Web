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

        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public void Update(User user)
        {
            var oldUser = context.Users.Find(user.Id);
            context.Entry(oldUser).CurrentValues.SetValues(user);
            context.SaveChanges();
        }
    }
}
