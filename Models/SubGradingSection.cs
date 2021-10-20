using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class SubGradingSection
    {
        public virtual GradingSection GradingSection { get; set; }

        public int GradingSectionID { get; set; }
        public string Name { get; set; }
        public int SubGradingSectionID { get; set; }
        public double MaxScore { get; set; }
    }
}
