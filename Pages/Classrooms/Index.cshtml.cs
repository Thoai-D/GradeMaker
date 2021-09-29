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

        public IList<ClassroomVM> Classrooms { get;set; }

        public async Task OnGetAsync()
        {

            Classrooms = await _context.Classrooms.Include(x => x.ClassTeacher)
                .Include(x => x.StudentClassrooms)
                .Select(x => new ClassroomVM(x))
                .ToListAsync();
        }
    }

    public class ClassroomVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int StudentCount { get; set; }

        public ClassroomVM(Classroom cr)
        {
            ID = cr.ClassroomID;
            Name = cr.ClassName;
            TeacherName = cr.ClassTeacher.FirstMidName;
            StudentCount = cr.StudentClassrooms.Count;
        }
    }

}
