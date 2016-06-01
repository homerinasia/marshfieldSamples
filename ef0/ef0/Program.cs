using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef0
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new pubsModel();
            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var query = from t in db.titles
                        orderby t.price
                        select new { t.title1, t.price, t.publisher.pub_name };

            foreach (var item in query)
            {
                Console.WriteLine(item.title1);
            }

            var sql = query.ToString();
            
                       
        }
    }
}
