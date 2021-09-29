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
    public class DetailsModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DetailsModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
