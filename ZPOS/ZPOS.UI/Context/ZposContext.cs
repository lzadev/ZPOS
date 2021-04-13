using Microsoft.EntityFrameworkCore;
using ZPOS.UI.Context.seedDB;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Context
{
    public class ZposContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public ZposContext(DbContextOptions<ZposContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedBrand());
            modelBuilder.ApplyConfiguration(new SeedCategory());
            modelBuilder.ApplyConfiguration(new SeedProduct());

            base.OnModelCreating(modelBuilder);
        }
    }
}
