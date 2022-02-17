using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        [BindProperty(SupportsGet = true)]
        public int StudentId { get; set; }

        public IndexModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollments { get;set; }

        public async Task OnGetAsync()
        {

            Enrollments = await _context.Enrollments
                .Where(e => e.StudentID == StudentId)
                .Include(e => e.Student)
                .Include(e => e.EnrollmentItem)
                    .ThenInclude(x => x.GradingSection)
                .Include(e => e.ClassroomTerm)
                    .ThenInclude(t => t.Classroom)
                .ToListAsync();
        }
    }
}
