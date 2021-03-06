using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ZPOS.UI.Context.seedDB;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Context
{
    public class ZposContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Client> Clients { get; set; }
        public ZposContext(DbContextOptions<ZposContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //modelBuilder.ApplyConfiguration(new SeedBrand());
            //modelBuilder.ApplyConfiguration(new SeedCategory());
            //modelBuilder.ApplyConfiguration(new SeedProduct());

            base.OnModelCreating(modelBuilder);

            foreach (var fks in modelBuilder.Model.FindEntityType(typeof(Product)).GetForeignKeys())
            {
                fks.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
