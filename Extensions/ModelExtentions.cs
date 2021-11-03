using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeMaker.Models;

namespace GradeMaker.Extensions
{
    public static class ModelExtentions
    {
        public static double MaxScore(this GradingSection g)
        {
            return g.SubGradingSections.Sum(x => x.MaxScore);
        }

        public static double CalculateGrade(this Student s, ClassroomTerm c)
        {
            double totalscoregs = 0; //total score of grading sections
            double totalscorest = 0; //total score of students per grading section
            double studentpercent = 0; //percentage student got out of the total weighting
            double gradingsectionweight; //Weighting of each gradin section
            double percenttoreturn = 0; //final return on how much percent the student got
                                        //on that term
            ClassroomTerm ct = c;

            List<Enrollment> studentenrollments = new List<Enrollment>();

            //LAMBDA expression to filter enrollments from student only within
            //this classroom term
            studentenrollments = s.Enrollments
                .Where(st => st.ClassroomTermID == c.ClassroomTermID).ToList();

            //first loop through grading sections
            for(int i = 0; i < ct.GradingSections.Count; i++)
            {
                gradingsectionweight = ct.GradingSections.ElementAt(i).Weighting;
                //loop through subgradingsections to get a total score
                for(int x = 0; x < ct.GradingSections.ElementAt(i)
                    .SubGradingSections.Count; x++)
                {
                    totalscoregs = totalscoregs + ct.GradingSections.ElementAt(i)
                        .SubGradingSections.ElementAt(x).MaxScore;
                }

                //After total score is taken, divide student's scores from enrollment by 
                //the total score
                for(int x = 0; x < studentenrollments.Count(); x++)
                {
                    if(studentenrollments[x].EnrollmentItem.GradingSectionID
                        == ct.GradingSections.ElementAt(i).GradingSectionID)
                    {
                        totalscorest = totalscorest + studentenrollments[x].Grade;
                    }
                }
                studentpercent = (totalscorest / totalscoregs) * 100;
                percenttoreturn = percenttoreturn + 
                    (studentpercent * gradingsectionweight) / 100;
            }
            return percenttoreturn;
        }
    }  
}
