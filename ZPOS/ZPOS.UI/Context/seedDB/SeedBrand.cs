using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Context.seedDB
{
    public class SeedBrand : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    ID = 1,
                    Name = "Nike"
                },
                new Brand
                {
                    ID = 2,
                    Name = "Addidas"
                },
                new Brand
                {
                    ID = 3,
                    Name = "Champion"
                },
                new Brand
                {
                    ID = 4,
                    Name = "Generico"
                }
           );
        }
    }
}
