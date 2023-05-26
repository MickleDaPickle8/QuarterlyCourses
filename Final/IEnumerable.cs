using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesDataBase
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
