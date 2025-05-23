﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Models;
using GradeMaker.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GradeMaker.Data
{
    public class SchoolContext : IdentityDbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<ClassroomTerm> ClassroomTerms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<GradingSection> GradingSections { get; set; }
        public DbSet<SubGradingSection> SubGradingSections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Classroom>().ToTable("Classroom");
            //    modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //    modelBuilder.Entity<Student>().ToTable("Student");
            //    modelBuilder.Entity<Teacher>().ToTable("Teacher");
            //    modelBuilder.Entity<ClassroomTerm>().ToTable("ClassroomTerm");
            //    modelBuilder.Entity<GradingSection>().ToTable("GradingSection");
            //    modelBuilder.Entity<SubGradingSection>().ToTable("SubGradingSection");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=School.db");
        }

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       //{
            //modelBuilder.Seed();
       //}

    }


}
