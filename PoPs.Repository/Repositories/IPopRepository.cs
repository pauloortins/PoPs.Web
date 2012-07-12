using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Repository.Repositories
{
    public interface IPopRepository
    {
        void Create(Pop pop);

        IEnumerable<Pop> GetAll();

        void Update(Pop pop);
    }
}
