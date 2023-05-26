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
    public partial class frmNewCourse : Form
    {
        public static frmNewCourse instance;
        public frmNewCourse()
        {
            InitializeComponent();
            instance = this;
        }
        //course 
        private Course course = null;

        public Course GetNewCourse()
        {
            //creates a method that can be used to both open the form and return a new course back to the course form
            this.ShowDialog();
            return course;
        }
        private void LoadComboBox()
        {
            //sets combobox items 
            cboIntructors.Items.Clear();
            cboIntructors.Items.Add("Ashraf Alattar");
            cboIntructors.Items.Add("Jeff McGuire");
            cboIntructors.Items.Add("Jimmy Dean");
            cboIntructors.Items.Add("Eli Schwartz");
            cboModality.Items.Add("In-Person");
            cboModality.Items.Add("fully-Online");
            cboModality.Items.Add("Hybrid");
            cboGrade.Items.Add("A");
            cboGrade.Items.Add("B");
            cboGrade.Items.Add("C");
            cboGrade.Items.Add("D");
            cboGrade.Items.Add("F");
            cboGrade.Items.Add("W");
            cboGrade.Items.Add("I");
        }

        private void frmNewCourse_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            //Unlocks the text files so you can type things. 
            txtCode.ReadOnly = false;
            txtTitle.ReadOnly = false;
            txtCredits.ReadOnly = false;
            txtDays.ReadOnly = false;
            txtTime.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          //Saves information from the text box then sent to the frmcourses. 
            string instructor = cboIntructors.Text;
            string modality = cboModality.Text;
            string grade = cboGrade.Text;
            string days = txtDays.Text;

            course = new Course(txtCode.Text, txtTitle.Text, Convert.ToInt32(txtCredits.Text), instructor, modality,
                days, txtTime.Text, grade);

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtCredits) &&
                Validator.IsWithinRange(txtCredits, 1, 5) &&
                   Validator.IsInt32(txtCredits) &&
                   Validator.IsPresent(txtDays) &&
                   Validator.IsPresent(txtTime) &&
                   Validator.IsPresent(txtTitle);

        }
    }
}
