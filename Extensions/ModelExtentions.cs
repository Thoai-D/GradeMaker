using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeMaker.Models;

namespace GradeMaker.Extensions
{
    public static class ModelExtentions
    {
        public static double MaxScore(this GradingSection g)
        {
            return g.SubGradingSections.Sum(x => x.MaxScore);
        }
    }  
}
