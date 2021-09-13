using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Classrooms
{
    public class IndexModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public IndexModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Classroom> Classrooms { get;set; }

        public async Task OnGetAsync()
        {

            Classrooms = await _context.Classrooms.ToListAsync();
        }
    }
}
