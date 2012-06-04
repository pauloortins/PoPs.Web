using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoPs.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pop> Pops { get; set; }
    }
}
