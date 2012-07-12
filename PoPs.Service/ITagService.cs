using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Service
{
    public interface ITagService
    {
        void Create(Tag tag);

        void Update(Tag tag);

        IEnumerable<Tag> GetAll();
    }
}
