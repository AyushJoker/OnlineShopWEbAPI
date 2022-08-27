using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }
        public int CID { get; set; }
        public decimal Price { get; set; }
        public string PName { get; set; }
        public string PDetail { get; set; }
        public string PImage1 { get; set; }
        public string PImage2 { get; set; }
        public string PImage3{ get; set; }
    }
}
