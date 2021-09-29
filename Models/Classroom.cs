using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class Classroom
    {
        public string ClassName { get; set; }

        public int ClassroomID { get; set; }

        public int ClassTeacherID { get; set; }

        public virtual Teacher ClassTeacher { get; set; }

        public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; }
        public virtual ICollection<ClassroomTerm> ClassroomTerms { get; set; }
    }
}
