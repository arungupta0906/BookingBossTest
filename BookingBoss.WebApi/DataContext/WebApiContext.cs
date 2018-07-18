using BookingBoss.WebApi.Models;
using BookingBoss.WebApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingBoss.WebApi.DataContext
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductEvent> ProductEvents { get; set; }
        public DbSet<ProductEventVM> ProductEventVMs { get; set; }
        public DbSet<ProductVM> ProductVMs { get; set; }
    }
}
