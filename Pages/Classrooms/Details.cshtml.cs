using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Classrooms
{
    public class DetailsModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DetailsModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public Classroom Classroom { get; set; }
        public List<StudentClassroomVM> Students { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classrooms
                .Include(c => c.ClassTeacher)
                .Include(c => c.ClassroomTerms)
                .AsNoTracking().FirstOrDefaultAsync(m => m.ClassroomID == id);

            var students = await _context.Students
                .Include(x => x.Enrollments)
                .ToListAsync();

            Students = students.Select(x => new StudentClassroomVM()
            {
                FirstName = x.FirstMidName,
                LastName = x.LastName,
                Enrollments = x.Enrollments.ToList(),
                StudentID = x.ID
            }).ToList();





            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

    public class StudentClassroomVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        public int StudentID { get; set; }
    }
}
