using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Models
{
    public class Category
    {
        [Key]
        public int CID { get; set; }
            public string CName { get; set; }
    }
}
