using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class ClassroomTerm
    {
        public int ClassroomTermID { get; set; }

        public int ClassroomID { get; set; }

        public string ClassroomTermName { get; set; }

        public virtual Classroom Classroom { get; set; }

        public virtual ICollection<GradingSection> GradingSections { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
