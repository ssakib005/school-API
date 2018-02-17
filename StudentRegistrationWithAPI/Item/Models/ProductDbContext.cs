using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Item.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}