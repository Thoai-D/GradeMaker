using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;
using GradeMaker.Models;
using GradeMaker.Extensions;

namespace GradeMaker.Pages.Classrooms
{
    public class DetailsModel : PageModel
    {
        private readonly GradeMaker.Data.SchoolContext _context;

        public DetailsModel(GradeMaker.Data.SchoolContext context)
        {
            _context = context;
        }

        public Classroom Classroom { get; set; }
        public List<StudentClassroomVM> Students { get; set; }

        /// <summary>
        /// On get Method that retrieves data from the database for the cshtml file 
        /// to load onto the webpage
        /// </summary>
        /// <param name="id">ClassroomID</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //If statement to return null if no route id is passed. 
            if (id == null)
            {
                return NotFound();
            }
            //Retrieving the classrooms from the database using the route id by LAMBDA expression
            Classroom = await _context.Classrooms
                .Include(c => c.ClassTeacher)
                .Include(c => c.ClassroomTerms)
                .AsNoTracking().FirstOrDefaultAsync(m => m.ClassroomID == id);

            //Retrieving students from the database
            var students = await _context.Students
                .Include(x => x.Enrollments)
                    .ThenInclude(x => x.EnrollmentItem)
                        .ThenInclude(x => x.GradingSection)
                .ToListAsync();

            //Creating a view model for the cshtml to display the data
            Students = students.Select(x => new StudentClassroomVM()
            {
                FirstName = x.FirstMidName,
                LastName = x.LastName,
                Enrollments = x.Enrollments.ToList(),
                StudentID = x.ID
            }).ToList();

            //If statement to 
            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }


    /// <summary>
    /// A class to represent the student to classroom relationship to display
    /// on the webpage
    /// </summary>
    public class StudentClassroomVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// Method to return the score of each student.
        /// Each score for each term will differ because the method takes in the parameter
        /// of the term's id.
        /// </summary>
        /// <param name="termid"></param>
        /// <returns>an int containing the student's percentage for the term</returns>
        public double Percentage(int termid)
        {   //Variable used to store the total score the student earned for a term
            //var p = Enrollments.Where(x => x.ClassroomTermID == termid).Sum(x => x.Grade);
            var allSubs = Enrollments.Where(x => x.ClassroomTermID == termid)
                .Select(x => new { Grade = x.Grade, Sub = x.EnrollmentItem });

            var gr = allSubs.GroupBy(x => x.Sub.GradingSection); // Key = GradingSection, Value: List<(Grade,Sub)>

            var p = gr.Sum(x =>
            {
                var list = x.ToList();
                var subs = list.Select(y => y.Sub).ToList();
                var maxSum = subs.Sum(x => x.MaxScore);
                var gradeSum = list.Sum(y => y.Grade);
                var weight = x.Key.Weighting;
                return (gradeSum * weight) / maxSum;
            });

            return p;

        } 
        
        
        

        public int StudentID { get; set; }
    }
}
