using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDataBase
{
    public class CourseList : IEnumerable<Course>
    {
        public List<Course> coursesList { get; set; }
        public List<Quarter> quartersList { get; set; }


        public List<Course> courses;
        public CourseList()
        {
            courses = new List<Course>();
        }

        public int Count => courses.Count;

        //creates indexer for the course list so courses can be accessed by index
        public Course this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }
                else if (i > courses.Count)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }
                return courses[i];
            }
            set
            {
                courses[i] = value;
            }
        }

        //add and remove methods for courses
        public void Add(Course course)
        {
            courses.Add(course);
        }

        public void Remove(Course course)
        {
            courses.Remove(course);
        }

        public void Add(string code, string title, int credits, string instructor, string modality, string days, string time, string grade)
        {
            Course i = new Course(code, title, credits, instructor, modality, days, time, grade);
            courses.Add(i);
        }

        //add and remove from the courselist
        public static CourseList operator +(CourseList cl, Course c)
        {
            cl.Add(c);
            return cl;
        }

        public static CourseList operator -(CourseList cl, Course c)
        {
            cl.Remove(c);
            return cl;
        }

        //return each course using an enumerator
        public IEnumerator<Course> GetEnumerator()
        {
            foreach (Course course in courses)
            {
                yield return course;
            }
        }
    }
}
