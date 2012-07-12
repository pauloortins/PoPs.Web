using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Repository.Repositories
{
    public class PopRepository : IPopRepository
    {
        private EFContext context;

        public PopRepository(EFContext context)
        {
            this.context = context;
        }

        public void Create(Domain.Pop pop)
        {
            context.Pops.Add(pop);
            context.SaveChanges();
        }

        public IEnumerable<Pop> GetAll()
        {
            return context.Pops;
        }

        public void Update(Pop pop)
        {
            Pop entity = context.Pops.FirstOrDefault(w => w.Id == pop.Id);

            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(pop);
                context.SaveChanges();
            }
            else
            {
                // ToDo: Throw exception
            }
        }
    }
}
