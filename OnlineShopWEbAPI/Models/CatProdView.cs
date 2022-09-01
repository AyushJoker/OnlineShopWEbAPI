using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Models
{
    public class CatProdView
    {
        [Key]
       public int PID { set; get; }
        public int CID { set; get; }
        public string PName { get; set; }
        public string PDetail { get; set; }

        public decimal Price { get; set; }

        public string PImage1 { get; set; }
        public string PImage2 { get; set; }
        public string PImage3 { get; set; }

        public string CName { get; set; }
        public int Isavailable { get; set; }

    }
}
