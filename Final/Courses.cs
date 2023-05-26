using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDataBase
{
    public class Course : IDisplayable1, ICloneable
    {
        private string code;
        private string title;
        private int credits;
        private string instructor;
        private string modality;
        private string days;
        private string time;
        private string grade;

        //course constructor
        public Course() { }

        //creates constructor with parameters for input to store courses
        public Course(string code, string title, int credits, string instructor, string modality, string days, string date, string grade)
        {
            this.code = code;
            this.title = title;
            this.credits = credits;
            this.instructor = instructor;
            this.modality = modality;
            this.days = days;
            this.time = date;
            this.grade = grade;
        }
        
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public int Credits
        {
            get
            {
                return credits;
            }
            set
            {
                credits = value;
            }
        }

        public string Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }

        public string Modality
        {
            get
            {
                return modality;
            }
            set
            {
                modality = value;
            }
        }

        public string Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }

        public Quarter Quarter { get; set; }


        //uses the idisplayable to get course display method for displaying courses
        public string GetCourseText()
        {
            return "Code: " + this.code + ", Course Title: " + this.title + ", Instructor: " + this.instructor +
                ", Modality: " + this.modality + ", Meeting Days: " + this.days + ", Starting Time: " + this.time + ", Grade: " + this.grade;
        }

        public object Clone()
        {
            //clone that can be used to edit courses
            Course course = new Course();
            this.code = course.code;
            this.title = course.title;
            this.instructor = course.instructor;
            this.modality = course.modality;
            this.credits = course.credits;
            this.days = course.days;
            this.time = course.time;
            this.grade = course.grade;
            return course;
        }
    }
}
