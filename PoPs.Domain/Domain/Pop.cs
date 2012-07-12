using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PoPs.Domain
{
    public class Pop
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual User User { get; set;}

        public virtual ICollection<Evaluation> Evaluations{get; set;}

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
