using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deleeteme
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Model1();
            var query = from s in db.sales
                        select s;

            
            
        }
    }
}
