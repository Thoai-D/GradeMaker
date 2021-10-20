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
    public class DetailsModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DetailsModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollments
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
