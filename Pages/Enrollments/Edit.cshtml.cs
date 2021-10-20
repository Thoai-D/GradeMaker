using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public EditModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }
        public async Task<IActionResult> OnGetAsync(int? studentid)
        {
            if (studentid == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollments
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.StudentID == studentid);

            if (Enrollment == null)
            {
                return NotFound();
            }
           ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.EnrollmentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnrollmentExists(int studentid)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == studentid);
        }
    }
}
