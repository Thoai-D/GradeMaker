using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.SubGradingSections
{
    public class DetailsModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DetailsModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public SubGradingSection SubGradingSection { get; set; }

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
    }
}
