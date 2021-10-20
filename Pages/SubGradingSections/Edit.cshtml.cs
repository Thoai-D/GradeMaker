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

namespace GradeMaker.Pages.SubGradingSections
{
    public class EditModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public EditModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubGradingSection SubGradingSection { get; set; }
        [BindProperty(SupportsGet = true)]
        public int GradingSectionId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubGradingSection = await _context.SubGradingSections.FirstOrDefaultAsync(m => m.SubGradingSectionID == id);

            if (SubGradingSection == null)
            {
                return NotFound();
            }
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

            _context.Attach(SubGradingSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubGradingSectionExists(SubGradingSection.SubGradingSectionID))
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

        private bool SubGradingSectionExists(int id)
        {
            return _context.SubGradingSections.Any(e => e.SubGradingSectionID == id);
        }
    }
}
