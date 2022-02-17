using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int StudentID { get; set; }

        public int ClassroomTermID { get; set; }

        public int SubGradingSectionID { get; set; }

        public double Grade { get; set; }

        public virtual SubGradingSection EnrollmentItem { get; set; }

        public virtual Student Student { get; set; }
        public virtual ClassroomTerm ClassroomTerm { get; set; }

    }
}
