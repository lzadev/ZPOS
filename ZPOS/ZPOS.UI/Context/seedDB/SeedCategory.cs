using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Context.seedDB
{
    public class SeedCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { ID = 1, Name = "Calzados" },
                new Category { ID = 2, Name = "Ropa" },
                new Category { ID = 3, Name = "Accesorios" }
            );
        }
    }
}
