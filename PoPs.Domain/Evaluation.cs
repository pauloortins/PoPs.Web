using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoPs.Domain
{
    public class Evaluation
    {
        public virtual User User { get; set; }
        public virtual Pop Pop { get; set; }
        public DateTime EvaluationDate { get; set; }
        public bool PositiveEvaluation { get; set; }
    }
}
