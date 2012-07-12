using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Service
{
    public interface IPopService
    {
        void Create(Pop user);

        void Update(Pop user);

        IEnumerable<Pop> GetAll();
    }
}
