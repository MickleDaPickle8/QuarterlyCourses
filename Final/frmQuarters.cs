using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace CoursesDataBase
{
    public partial class frmQuarters : Form
    {
        public static frmQuarters instance;
        public List<Quarter> quartersList = new List<Quarter>();
        //Sets the Message, title and default value of the InputBox to be displayed
        private string msg = "Please add new quarter!";
        private string title = "Quarter Entry";
        private string defaultValue = "Enter quarter here: 'example: Fall 2019...'";
        public string inputMessage = "";
        public string message;

        public frmQuarters()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //instantiates a new Input box
            var inputMsg = Interaction.InputBox(msg,title,defaultValue,-1,-1);
            // if the okay button is clicked it will add the text to the Input to the list box to display the quarter
            //if the user does not include anything to the text box it will close the inputbox
            if ((string)inputMsg != "")
            {
                // adding the new quarter to the quarters listbox
                //lstQuarters.Items.Add(inputMsg.ToString());

                // create a new quarter object with inputMsg as the quarter name 
                Quarter quarter = new Quarter(inputMsg);

                // adding the new quarter to the quarterlist object
                quartersList.Add(quarter);
                QuarterDB.SaveQuarters(quartersList);

            }
            else if ((inputMsg == ""))
            {
                MessageBox.Show("Please enter quarter!","Entry Error!");
            }
            message = inputMsg;
            // call FillQuarterListBox to refresh the list  box after the new quarter has been added
            FillQuarterListBox();
            txtCount.Text = lstQuarters.Items.Count.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //insinstantiates a new Input box for the quater to be updated. Once the input has been sent through it will claer the list and repoulate the list
            //with the updated version of the new qaurter.
            var updateQuater = Interaction.InputBox(msg,title,"Update Quarter!", -1, -1);
            int i = lstQuarters.SelectedIndex;
            if (i != -1)
            {
                if ((string)updateQuater != "")
                {
                    Quarter quarter = new Quarter(updateQuater);
                    quartersList.RemoveAt(i);
                    quartersList.Add(quarter);
                    
                    QuarterDB.SaveQuarters(quartersList);
                    FillQuarterListBox();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //at the selected index it will delete the quarter clear the list and repopulate what is left. then save the items to a text file.
            int i = lstQuarters.SelectedIndex;
            
            if (i != -1)
            {
                Quarter quarter = (Quarter)quartersList[i];
                string message = "Are you sure you want to delete this quarter " 
                    + quarter.name + "?";
                DialogResult button =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    quartersList.RemoveAt(i);
                    FillQuarterListBox();
                    QuarterDB.SaveQuarters(quartersList);
                    txtCount.Text = lstQuarters.Items.Count.ToString();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close application
            this.Close();
        }

        private void frmQuarters_Load(object sender, EventArgs e)
        {
            //on load it will pull data from the text file to be displayed and what objects are in the list will be counted and the list box will be refilled
            List<Quarter> quarters = new List<Quarter>();
            quartersList = QuarterDB.GetQuarters();
            FillQuarterListBox();
            txtCount.Text = lstQuarters.Items.Count.ToString();
        }

        private void btnAddClasses_Click(object sender, EventArgs e)
        {
            //opens a new form to add classes to a new list. and calclates GPA and total credits given on the selected index.
            int i = lstQuarters.SelectedIndex;
            if (i != -1)
            {
                frmCourses newQuarterForm = new frmCourses();
                Quarter quarter = newQuarterForm.GetNewQuarter();
                txtGPA.Text = frmCourses.instance.Gpa().ToString();
                txtTotalCredits.Text = frmCourses.instance.GetCredits().ToString();
            }
        }

        private void FillQuarterListBox()
        {
            //fills the list box with the quarters in the quarterslist by getting its name.
            lstQuarters.Items.Clear();
            Quarter quarter;
            for (int i = 0; i < quartersList.Count; i++)
            {
                quarter = quartersList[i];
                lstQuarters.Items.Add(quarter.name);
            }
        }
        public string GetQuarterTags()
        {
            //Gets the name based on the selected index text. then sends it to the form to then display a lable.
            string text = "";
            int i = lstQuarters.SelectedIndex;
            if (i != -1)
            {
                text = lstQuarters.Text;
            }
            return text;
        }
    }
}
