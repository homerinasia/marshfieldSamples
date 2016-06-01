using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubsDTO.Models
{
    public class titlesDTO
    {
        public string title_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string pubName { get; set; }        
        public int? ytd_sales { get; set; }
        public DateTime pubdate { get; set; }
    }
}
