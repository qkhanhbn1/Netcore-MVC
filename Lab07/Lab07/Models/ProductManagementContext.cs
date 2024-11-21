using Microsoft.EntityFrameworkCore;
using System;

namespace Lab07.Models
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners {  get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
