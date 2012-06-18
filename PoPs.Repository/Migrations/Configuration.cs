namespace PoPs.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PoPs.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<PoPs.Repository.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFContext context)
        {
            AddUsers(context);
        }

        private void AddUsers(EFContext context)
        {
            context.Users.Add(new User() {
                Login = "abcd",
                Email = "abcd@gmail.com",
                Password = "81DC9BDB52D04DC20036DBD8313ED055"
            });
            context.SaveChanges();
        }
    }
}
