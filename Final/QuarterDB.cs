using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoursesDataBase
{
    public static class QuarterDB
    {
        private const string path = @"..\..\Quarters.txt";

        //gets and reads the text file. to then be displayed by other methods.
        public static List<Quarter> GetQuarters()
        { 
            List<Quarter> quarters = new List<Quarter>();

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader textIn = new StreamReader(fs);

            while (textIn.Peek() != -1)
            { 
                string row = textIn.ReadLine();
                string field = row;

                Quarter quarter = new Quarter();
                quarter.name = field;

                quarters.Add(quarter);
            }
            textIn.Close();

            return quarters;
        }

        public static void SaveQuarters(List<Quarter> quarters)
        {
            //saves quarter data to a texct file. to then be read.
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter textOut = new StreamWriter(fs);

            foreach (Quarter quarter in quarters)
            {
                textOut.WriteLine(quarter.name);
            }
            textOut.Close();
        }
    }
}
