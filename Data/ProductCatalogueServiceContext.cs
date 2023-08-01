using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalogueService.Models;

namespace ProductCatalogueService.Data
{
    public class ProductCatalogueServiceContext : DbContext
    {
        public ProductCatalogueServiceContext (DbContextOptions<ProductCatalogueServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCatalogueService.Models.User> User { get; set; } = default!;

        public DbSet<ProductCatalogueService.Models.Product>? Product { get; set; }

        public DbSet<ProductCatalogueService.Models.Transaction>? Transaction { get; set; }



    }
}
