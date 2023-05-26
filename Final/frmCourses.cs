using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursesDataBase
{
    public partial class frmCourses : Form
    {
        //create variables to be used in class
        public static frmCourses instance;
        public List<Course> courses = new List<Course>();
        public string Code = "";
        public string Title;
        public string Instructor;
        public string Modality;
        public string Days;
        public string Time;
        public int Credits;
        private string Grade = "";
        private decimal grade;


        private void FillCourseListBox()
        {
            //create method to fill the listbox with the courses
            lstCourses.Items.Clear();
            Course course;
            for (int i = 0; i < courses.Count; i++)
            {
                   course = courses[i];
                   lstCourses.Items.Add(course.GetCourseText());
            }
        }


        public frmCourses()
        {
            InitializeComponent();
            instance = this;
        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            //loads the title of the quarter and the courses
            string msg = frmQuarters.instance.GetQuarterTags();
            lblQuarterXcourses.Text = "Quarter " + msg + " courses:";
            courses = CourseDB.GetCourses();
            FillCourseListBox();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //pulls up the new course form, calls the new course, and adds it to the course list
            frmNewCourse newCourseform = new frmNewCourse();
            Course course = newCourseform.GetNewCourse();
            if (course != null)
            {
                courses.Add(course);
                CourseDB.SaveCourses(courses);
                FillCourseListBox();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //this selects a course that you want to edit, deletes it from the list, and adds the new course to the list
            int i = lstCourses.SelectedIndex;
            if (i != -1)
            {
                frmNewCourse newCourseform = new frmNewCourse();
                Course course = newCourseform.GetNewCourse();
                if (course != null)
                {
                    courses.RemoveAt(i);
                    courses.Add(course);
                    CourseDB.SaveCourses(courses);
                    FillCourseListBox();
                }
            }
        }


        private void btn_Click(object sender, EventArgs e)
        {
            //deletes the course from the list and saves the listbox
            int i = lstCourses.SelectedIndex;
            if (i != -1)
            {

                Course course = (Course)courses[i];
                courses.Remove(course);
                CourseDB.SaveCourses(courses);
                FillCourseListBox();
            }
        }

        Quarter quarter = new Quarter();
        public Quarter GetNewQuarter()
        {
            //this method i used to open the course form from the quarter form
            this.ShowDialog();
            return quarter;
        }

        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            //validate the user is selecting a list index then will display the text of the selected index of the course in a message box
            int index = 0;
            string message = "";
            if (lstCourses.SelectedIndex == -1)
            {
                MessageBox.Show("Must select course entry.", "Error");
            }
            else
            {
                index = lstCourses.SelectedIndex;
                message = courses[index].GetCourseText();
                MessageBox.Show(message);
            }
        }

        private void lstCourses_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //display course info in text boxes
            int i = lstCourses.SelectedIndex;
            if (i != -1)
            {
                Course course = courses[i];
                txtCredits.Text = course.Credits.ToString();
                txtGrade.Text = course.Grade.ToString();
                txtModality.Text = course.Modality.ToString();
            }
        }

        public decimal GetGpa()
        {
            //do the calculations for gpa that will be used to send the gpa value to the quarter form
            string i = "";
            decimal grd = 0;
            int count = 0;
            foreach (Course course in courses)
            {

                i = course.Grade;
                if (i == "A")
                {
                    grd = 4;
                }
                else if (i == "B")
                {
                    grd = 3;
                }
                else if (i == "C")
                {
                    grd = 2;
                }
                else if (i == "D")
                {
                    grd = 1;
                }
                else if (i == "F")
                {
                    grd = 0;
                }
                else
                {
                    grd = 0;
                    count -= 1;
                }

                grade += grd;
                count+=1;
            }
            grade = grade / count;
            return grade;
        }

        public int GetCredits()
        {
            //calculate the total credits based on each course in the list and retrun to main form
            foreach (Course c in courses)
            {
                int crd = c.Credits;
                Credits += crd;
            }
            return Credits;
        }

        public decimal Gpa()
        {
            //return grade to quarter form
            return grade = GetGpa();
        }

        private bool IsValidData()
        {
            //create validator for textbox entry values
            return Validator.IsPresent(txtCredits) &&
                Validator.IsWithinRange(txtCredits, 1, 5) &&
                   Validator.IsInt32(txtCredits);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close
            this.Close();
        }
    }
}
