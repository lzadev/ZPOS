using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Context.seedDB
{
    public class SeedProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {   
                    ID=1,
                    Code = "002236",
                    Description = "Meidas unisex x3",
                    CategoryID = 3,
                    BrandID = 1,
                    BuyPrice = 400.50M,
                    SellPrice = 600,
                    CreationDate = DateTime.Now
                },
                new Product
                {
                    ID = 2,
                    Code = "002238",
                    Description = "Chancletas sport size 10",
                    CategoryID = 1,
                    BrandID = 1,
                    BuyPrice = 850.50M,
                    SellPrice = 1600.38M,
                    CreationDate = DateTime.Now
                },
                new Product
                {
                    ID = 3,
                    Code = "002256",
                    Description = "T shirt crema ",
                    CategoryID = 2,
                    BrandID = 4,
                    BuyPrice = 850.50M,
                    SellPrice = 1600.38M,
                    CreationDate = DateTime.Now
                }
            );
        }
    }
}
