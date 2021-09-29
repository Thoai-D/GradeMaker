﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeMaker.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
