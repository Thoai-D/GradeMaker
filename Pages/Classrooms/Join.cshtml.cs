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

namespace GradeMaker.Pages.Classrooms
{
    public class JoinModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public JoinModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Classroom Classroom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classrooms
                .Include(c => c.ClassTeacher).FirstOrDefaultAsync(m => m.ClassroomID == id);

            if (Classroom == null)
            {
                return NotFound();
            }
           ViewData["ClassTeacherID"] = new SelectList(_context.Teachers, "ID", "ID");
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

            _context.Attach(Classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(Classroom.ClassroomID))
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

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomID == id);
        }
    }
}
