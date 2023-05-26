using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDataBase
{
    public interface IDisplayable1
    {
        //create display string that can be overridden to display courses
        string GetCourseText();
    }
}
