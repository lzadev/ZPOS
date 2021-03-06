// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZPOS.UI.Context;

namespace ZPOS.UI.Migrations
{
    [DbContext(typeof(ZposContext))]
    [Migration("20210419212925_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZPOS.UI.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Nike"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Addidas"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Champion"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Generico"
                        });
                });

            modelBuilder.Entity("ZPOS.UI.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Calzados"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Ropa"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Accesorios"
                        });
                });

            modelBuilder.Entity("ZPOS.UI.Entities.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ZPOS.UI.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BrandID = 1,
                            BuyPrice = 400.50m,
                            CategoryID = 3,
                            Code = "002236",
                            CreationDate = new DateTime(2021, 4, 19, 17, 29, 24, 685, DateTimeKind.Local).AddTicks(2571),
                            Description = "Meidas unisex x3",
                            SellPrice = 600m,
                            Status = false
                        },
                        new
                        {
                            ID = 2,
                            BrandID = 1,
                            BuyPrice = 850.50m,
                            CategoryID = 1,
                            Code = "002238",
                            CreationDate = new DateTime(2021, 4, 19, 17, 29, 24, 686, DateTimeKind.Local).AddTicks(795),
                            Description = "Chancletas sport size 10",
                            SellPrice = 1600.38m,
                            Status = false
                        },
                        new
                        {
                            ID = 3,
                            BrandID = 4,
                            BuyPrice = 850.50m,
                            CategoryID = 2,
                            Code = "002256",
                            CreationDate = new DateTime(2021, 4, 19, 17, 29, 24, 686, DateTimeKind.Local).AddTicks(819),
                            Description = "T shirt crema ",
                            SellPrice = 1600.38m,
                            Status = false
                        });
                });

            modelBuilder.Entity("ZPOS.UI.Entities.Product", b =>
                {
                    b.HasOne("ZPOS.UI.Entities.Brand", "Brands")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ZPOS.UI.Entities.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
