using SwaggerClient0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swaggerClient0
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program p = new Program();
            var client = new SimpleWebAPIEFCFJoin();
            var salesResults = client.Sales.Getsales();
            foreach (var v in salesResults)
            {
                Console.WriteLine(v.OrdNum);
            }

            var stresults = client.SmallTitles.GetsmallTitles();
            foreach (var v in stresults)
            {
                Console.WriteLine(v.Title1);
            }

        }        
    }
}