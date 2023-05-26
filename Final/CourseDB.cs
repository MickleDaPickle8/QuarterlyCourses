using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoursesDataBase
{
    public static class CourseDB
    {
        private const string path = @"..\..\Courses.txt";

        public static List<Course> GetCourses()
        { 
            //gets and reads the text file. to then be displayed by other methods.
            List<Course> courses = new List<Course>();

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader textIn = new StreamReader(fs);

            while (textIn.Peek() != -1)
            { 
                string row = textIn.ReadLine();
                string[] fields = row.Split('|');

                Course course = new Course();
                course.Code = fields[0];
                course.Title = fields[1];
                course.Instructor = fields[2];
                course.Modality = fields[3];
                course.Credits = Convert.ToInt32(fields[4]);
                course.Days = fields[5];
                course.Time = fields[6];
                course.Grade = fields[7];

                courses.Add(course);
            }
            textIn.Close();

            return courses;
        }

        public static void SaveCourses(List<Course> courses)
        { 
            //saves course data to a texct file. to then be read.
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter textOut = new StreamWriter(fs);

            foreach (Course course in courses)
            { 
                textOut.Write(course.Code + "|");
                textOut.Write(course.Title + "|");
                textOut.Write(course.Instructor + "|");
                textOut.Write(course.Modality + "|");
                textOut.Write(course.Credits + "|");
                textOut.Write(course.Days + "|");
                textOut.Write(course.Time + "|");
                textOut.WriteLine(course.Grade);
            }

            textOut.Close();
        }

    }
}
