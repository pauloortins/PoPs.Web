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
    public class PopService : IPopService
    {
        IPopRepository repository;

        public PopService(IPopRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Pop pop)
        {
            repository.Create(pop);
        }

        public void Update(Pop pop)
        {
            repository.Update(pop);
        }

        public IEnumerable<Pop> GetAll()
        {
            return repository.GetAll();
        }
    }
}
