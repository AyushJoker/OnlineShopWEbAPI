using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CatProdView> CatIdwiseProducts { get; set; }

        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<CartOrder> CartOrders { get; set; }
        public DbSet<Admin> Admins { get; set; }

     


    }
}
