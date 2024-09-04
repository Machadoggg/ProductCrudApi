using Microsoft.EntityFrameworkCore;
using ProductCrud.Core.Entities;
using System;

namespace ProductCrud.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
