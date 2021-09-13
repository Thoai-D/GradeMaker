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
    public class DetailsModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DetailsModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public ClassroomTerm ClassroomTerm { get; set; }
        public int ClassroomID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassroomTerm = await _context.ClassroomTerms
                .Include(c => c.Classroom).FirstOrDefaultAsync(m => m.ClassroomTermID == id);
            ClassroomID = (int)id;

            if (ClassroomTerm == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
