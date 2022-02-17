using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.SubGradingSections
{
    public class CreateModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public CreateModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SubGradingSection SubGradingSection { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GradingSectionId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SubGradingSection.GradingSectionID = GradingSectionId;

            _context.SubGradingSections.Add(SubGradingSection);
            await _context.SaveChangesAsync();

            return RedirectToPage("/GradingSections/Edit", new { GradingSectionId = GradingSectionId});
        }
    }
}
