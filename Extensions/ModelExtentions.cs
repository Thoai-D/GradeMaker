using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeMaker.Models;

namespace GradeMaker.Extensions
{
    public static class ModelExtentions
    {
        /// <summary>
        /// Method that returns the total score of each gradingsection's
        /// subgrading section scores combined.
        /// </summary>
        /// <param name="g"></param>
        /// <returns>a double containing the total score of each subgrading 
        ///          section combined</returns>
        public static double MaxScore(this GradingSection g)
        {
            return g.SubGradingSections.Sum(x => x.MaxScore);
        }

        /// <summary>
        /// This extension method calculates the student's total grade.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns>Returns a double with the perentage the 
        /// student got within the classroom</returns>
        public static double CalculateGrade(this Student s, ClassroomTerm c)
        {
            double totalscoregs = 0; //total score of grading sections
            double totalscorest = 0; //total score of students per grading section
            double studentpercent = 0; //percentage student got out of the total weighting
            double gradingsectionweight; //Weighting of each grading section
            double percenttoreturn = 0; //final return on how much percent the student got
                                        //on that term

            ClassroomTerm ct = c; //The classroom taken from the parameter. 
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
                    //If statement to ensure that the enrollment it is looping through is 
                    //from the same grading section. 
                    if(studentenrollments[x].EnrollmentItem.GradingSectionID
                        == ct.GradingSections.ElementAt(i).GradingSectionID)
                    {
                        totalscorest = totalscorest + studentenrollments[x].Grade;
                    }
                }
                //Dividing the total score of the student by the total score of the gradingsections
                //and multiplying it by 100 to get a percentage
                studentpercent = (totalscorest / totalscoregs) * 100;

                //Adding in the percent of every grading section to the percenttoreturn variable.
                //This will give the percentage score of each student
                percenttoreturn = percenttoreturn + 
                    (studentpercent * gradingsectionweight) / 100;

                totalscoregs = 0; //reset the score for every grading section
                totalscorest = 0; //reset student total score after each grading section
            }
            return percenttoreturn;
        }


    }  
}
