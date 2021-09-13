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
    public class DeleteModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DeleteModel(GradeMaker.Data.SchoolContext context)
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

            Classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.ClassroomID == id);

            if (Classroom == null)
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

            Classroom = await _context.Classrooms.FindAsync(id);

            if (Classroom != null)
            {
                _context.Classrooms.Remove(Classroom);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
