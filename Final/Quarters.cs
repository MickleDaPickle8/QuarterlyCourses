using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDataBase
{
    //create quarter class that accepts course objects
    public class Quarter : Course
    {
        public string ID;
        public string name = "";
        List<Course> coursesList = new List<Course>();

        public Quarter()
        { 
            
        }
        //quarter constructor for quartername
        public Quarter(string quarterName)
        {
            this.name = quarterName;
        }

    }
}

