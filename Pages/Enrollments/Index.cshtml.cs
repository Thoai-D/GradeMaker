using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public IndexModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; }

        public async Task OnGetAsync()
        {
            Enrollment = await _context.Enrollments
                .Include(e => e.Student).ToListAsync();
        }
    }
}
