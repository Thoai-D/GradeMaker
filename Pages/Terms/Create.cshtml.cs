using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Terms
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
            //ViewData["ClassroomID"] = new SelectList(_context.Classrooms, "ClassroomID", "ClassroomID");
            return Page();
        }

        [BindProperty]
        public ClassroomTerm ClassroomTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ClassroomID { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ClassroomTerm.ClassroomID = ClassroomID;

            _context.ClassroomTerms.Add(ClassroomTerm);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Classrooms/Details", new { ID = ClassroomID });
        }
    }
}
