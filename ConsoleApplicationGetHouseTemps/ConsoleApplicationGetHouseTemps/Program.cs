using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace ConsoleApplicationGetHouseTemps
{
    class Program
    {
        static void Main(string[] args)
        {
            houseTempRestHelper hr = new houseTempRestHelper();
            var temps = hr.getHouseTemps();
            var temp = hr.getHouseTempById(200);
        }
    }

    public class houseTempRestHelper
    {
        readonly string baseUri = "http://piwebapi020160503084421.azurewebsites.net/api/housetemps";

        public List<houseTemp> getHouseTemps()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(baseUri);
                return JsonConvert.DeserializeObjectAsync<List<houseTemp>>(response.Result).Result;
            }            
        }

        public houseTemp getHouseTempById(int Id)
        {
            string uri = baseUri + "/" + Id;
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<houseTemp>(response.Result).Result;
            }
        }
    }

    public class houseTemp
    {
        public int Id { get; set; }
        public string  tds { get; set; }
        public decimal tempF { get; set; }
    }
}


























/* 
{"Id":183,"tds":"2016-05-05T20:50:02","tempF":74.41}



    */
