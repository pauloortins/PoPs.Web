using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PoPs.Domain;

namespace PoPs.Repository
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pop> Pops { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
    }
}
