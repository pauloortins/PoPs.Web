using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoPs.Domain;

namespace PoPs.Repository.Repositories
{
    public class TagRepository : ITagRepository
    {
        private EFContext context;

        public TagRepository(EFContext context)
        {
            this.context = context;
        }

        public void Create(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }

        public IEnumerable<Tag> GetAll()
        {
            return context.Tags;
        }

        public void Update(Tag tag)
        {
            Tag entity = context.Tags.FirstOrDefault(w => w.Id == tag.Id);

            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(tag);
                context.SaveChanges();
            }
            else
            {
                // ToDo: Throw exception
            }
        }
    }
}
