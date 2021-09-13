using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeMaker.Models;
using Microsoft.Extensions.Logging;

namespace GradeMaker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context, ILogger logger)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                logger.LogInformation("Database existed! No seeding.");
                return;   // DB has been seeded
            }
            logger.LogInformation("Seeding the database");

            var teachers = new Teacher[]
{
                new Teacher{FirstMidName = "Mr. John"},
                new Teacher{FirstMidName = "Mr. Joe"},
                new Teacher{FirstMidName = "Mrs. Jane"},
};
            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            var classrooms = new Classroom[]
{
                new Classroom{ClassName = "English",ClassTeacherID = 1},
                new Classroom{ClassName = "Spanish", ClassTeacherID = 2},
                new Classroom{ClassName = "Biology", ClassTeacherID = 3},
};
            context.Classrooms.AddRange(classrooms);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student{FirstMidName = "Thoai", LastName = "Do"},
                new Student { FirstMidName = "Khang", LastName = "Do" },
                new Student { FirstMidName = "John", LastName = "Smith" },
                new Student { FirstMidName = "Jane", LastName = "Smith" },
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var classroomTerms = new ClassroomTerm[]
            {
                new ClassroomTerm{ClassroomID = 1, ClassroomTermName = "Term 1"},
                new ClassroomTerm{ClassroomID = 1, ClassroomTermName = "Term 2"},
                new ClassroomTerm{ClassroomID = 1, ClassroomTermName = "Term 3"},
                new ClassroomTerm{ClassroomID = 2, ClassroomTermName = "Term 1"},
                new ClassroomTerm{ClassroomID = 2, ClassroomTermName = "Term 2"},
                new ClassroomTerm{ClassroomID = 3, ClassroomTermName = "Term 1"},
            };
            context.ClassroomTerms.AddRange(classroomTerms);
            context.SaveChanges();


            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID = 1, ClassroomTermID = 1, Grade = 50},
                new Enrollment{StudentID = 2, ClassroomTermID = 2, Grade = 90.5},
                new Enrollment{StudentID = 3, ClassroomTermID = 2, Grade = 86},
                new Enrollment{StudentID = 4, ClassroomTermID = 3, Grade = 88},
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();




        }
    }
}
