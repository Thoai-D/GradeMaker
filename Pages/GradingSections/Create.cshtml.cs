using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.GradingSections
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
        public GradingSection GradingSection { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GradingSections.Add(GradingSection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
