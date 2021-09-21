using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Terms
{
    public class DeleteModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DeleteModel(GradeMaker.Data.SchoolContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassroomTerm = await _context.ClassroomTerms.FindAsync(id);

            int classid = ClassroomTerm.ClassroomID;
            if (ClassroomTerm != null)
            {
                _context.ClassroomTerms.Remove(ClassroomTerm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { classroomID = classid });
        }
    }
}
