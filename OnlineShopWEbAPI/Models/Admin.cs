using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Models
{
    public class Admin
    {
        [Key]
        public int AID { get; set; }

        public string username { get; set; }

        public string Password { get; set; }
    }
}
