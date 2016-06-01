using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProMVCCh1.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="name?")]
        public string  Name { get; set; }
        public string  Email { get; set; }
        public string  Phone { get; set; }

        [Required(ErrorMessage = "you comin or not????")]
        public bool? WillAttend { get; set; }
    }
}
