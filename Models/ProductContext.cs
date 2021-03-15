using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductCRUD.Models
{
        public class ProductContext : DbContext
        {
            public ProductContext(DbContextOptions<ProductContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }

            public DbSet<Product> Products { get; set; }
        }
    
}
