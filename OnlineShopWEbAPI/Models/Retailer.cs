using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Models
{
    public class Retailer
    {
        [Key]
        public int RID { get; set; }
        public int AID { get; set; }

        public string RName { get; set; }

        public string email { get; set; }

        public string Password { get; set; }
        public string Contactnumber { get; set; }
    }
}
