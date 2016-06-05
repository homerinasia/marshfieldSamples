using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using mvc_ef_cf.Models;

namespace mvc_ef_cf
{
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

}
