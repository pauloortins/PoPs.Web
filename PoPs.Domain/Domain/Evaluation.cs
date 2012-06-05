using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PoPs.Domain
{
    public class Evaluation
    {
        [Key]
        public Int32 Id { get; set; }
        public DateTime EvaluationDate { get; set; }
        public bool PositiveEvaluation { get; set; }

        public virtual User User { get; set; }
        public virtual Pop Pop { get; set; }
    }
}
