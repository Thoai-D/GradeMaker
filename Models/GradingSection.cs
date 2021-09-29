using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class GradingSection
    {
        public int GradingSectionID { get; set; }

        public string Name { get; set; }

        public double Weighting { get; set; }

        public double Score { get; set; }

        public virtual ClassroomTerm ClassroomTerm { get; set; }
        public virtual ICollection<SubGradingSection> SubGradingSections { get; set; }
    }
}
