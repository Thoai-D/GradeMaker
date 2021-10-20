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

namespace GradeMaker.Pages.GradingSections
{
    public class EditModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public EditModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GradingSection GradingSection { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TermId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GradingSectionId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? GradingSectionId)
        {
            if (GradingSectionId == null)
            {
                return NotFound();
            }

            GradingSection = await _context.GradingSections
                .Include(x => x.ClassroomTerm)
                .Include(x => x.SubGradingSections)
                .FirstOrDefaultAsync(m => m.GradingSectionID == GradingSectionId);

            if (GradingSection == null)
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

            _context.Attach(GradingSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradingSectionExists(GradingSection.GradingSectionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Terms/Edit", new { ID = TermId });
        }

        private bool GradingSectionExists(int id)
        {
            return _context.GradingSections.Any(e => e.GradingSectionID == id);
        }
    }
}
