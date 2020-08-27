using Com.Solution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Solution.Infraestructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
    }
}
