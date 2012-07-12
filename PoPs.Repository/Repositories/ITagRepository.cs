using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Repository.Repositories
{
    public interface ITagRepository
    {
        void Create(Tag tag);

        IEnumerable<Tag> GetAll();

        void Update(Tag tag);
    }
}
