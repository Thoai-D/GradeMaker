using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.GradingSections
{
    public class DeleteModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DeleteModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GradingSection GradingSection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GradingSection = await _context.GradingSections.FirstOrDefaultAsync(m => m.GradingSectionID == id);

            if (GradingSection == null)
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

            GradingSection = await _context.GradingSections.FindAsync(id);

            if (GradingSection != null)
            {
                _context.GradingSections.Remove(GradingSection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
