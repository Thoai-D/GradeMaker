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

namespace GradeMaker.Pages.Terms
{
    public class EditModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public EditModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassroomTerm ClassroomTerm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassroomTerm = await _context.ClassroomTerms
                .Include(c => c.Classroom).FirstOrDefaultAsync(m => m.ClassroomTermID == id);

            if (ClassroomTerm == null)
            {
                return NotFound();
            }
           ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "ClassroomID", "ClassroomID");
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

            _context.Attach(ClassroomTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomTermExists(ClassroomTerm.ClassroomTermID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Classrooms/Details", new { ID = ClassroomTerm.ClassroomID });
        }

        private bool ClassroomTermExists(int id)
        {
            return _context.ClassroomTerms.Any(e => e.ClassroomTermID == id);
        }
    }
}
