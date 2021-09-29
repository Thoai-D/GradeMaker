using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class StudentClassroom
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int ClassroomID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
