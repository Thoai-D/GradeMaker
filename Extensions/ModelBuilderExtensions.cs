using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Models;
using GradeMaker.Data;

namespace GradeMaker.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    FirstMidName = "John",
                    LastName = "Smith",
                    ID = 1
                }
            );

            var classrooms = new List<Classroom>() {
                new Classroom
                {
                    ClassName = "English",
                    ClassTeacherID = 1,
                    ClassroomID = 1
                }
            };

            var students = new List<Student>() {
                new Student
                {
                    FirstMidName = "Thoai", ID = 1
                },
                new Student
                {
                    FirstMidName = "Khang", ID = 2
                },
                new Student
                {
                    FirstMidName = "Peter", ID = 3
                },

            };

            modelBuilder.Entity<Classroom>().HasData(classrooms);
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<StudentClassroom>().HasData(
                new StudentClassroom { ClassroomID = 1, StudentID = 1, ID = -1},
                new StudentClassroom { ClassroomID = 1, StudentID = 2, ID = -2},
                new StudentClassroom { ClassroomID = 1, StudentID = 3, ID = -3}
                );

            modelBuilder.Entity<ClassroomTerm>().HasData(
                new ClassroomTerm
                {
                    ClassroomTermID = 1,
                    ClassroomID = 1,
                    ClassroomTermName = "Term 1"
                },

                new ClassroomTerm
                {
                    ClassroomTermID = 2,
                    ClassroomID = 1,
                    ClassroomTermName = "Term 2"
                },

                new ClassroomTerm
                {
                    ClassroomTermID = 3,
                    ClassroomID = 1,
                    ClassroomTermName = "Term 3"
                }
                ); ;



            return modelBuilder;
        }
    }
}
