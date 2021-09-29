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
    public class EditStudentPageModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;
        public EditStudentPageModel(GradeMaker.Data.SchoolContext context)
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

            var students = await _context.Classrooms
                .Include(x => x.StudentClassrooms)
                    .ThenInclude(x => x.Classroom)
                .Where(x => x.ClassroomID == id)
                .SelectMany(x => x.StudentClassrooms)
                .Select(x => x.Student)
                .ToListAsync();

            Students = students.Select(x => new StudentClassroomVM()
            {
                FirstName = x.FirstMidName,
                LastName = x.LastName,
                Enrollments = x.Enrollments.ToList()
            }).ToList();





            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
