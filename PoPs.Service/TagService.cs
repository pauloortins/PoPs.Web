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
    public class TagService : ITagService
    {
        ITagRepository repository;

        public TagService(ITagRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Tag tag)
        {
            repository.Create(tag);
        }

        public void Update(Tag tag)
        {
            repository.Update(tag);
        }

        public IEnumerable<Tag> GetAll()
        {
            return repository.GetAll();
        }
    }
}
