using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;

namespace GradeMaker.Pages.Terms
{
    public class IndexModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public IndexModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<ClassroomTerm> ClassroomTerm { get;set; }

        public int ClassroomID { get; set; }

        public async Task OnGetAsync(int classroomId)
        {
            ClassroomID = classroomId;
            ClassroomTerm = await _context.ClassroomTerms
                .Include(c => c.Classroom)
                .Where(c => c.ClassroomID == classroomId)
                .ToListAsync();
        }
    }
}
