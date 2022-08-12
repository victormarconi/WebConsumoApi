﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebConsumoApi.DBContext;

#nullable disable

namespace WebConsumoApi.Migrations
{
    [DbContext(typeof(DbProdutosContext))]
    partial class DbProdutosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebConsumoApi.Models.ProdutoDB", b =>
                {
                    b.Property<string>("Sku")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Depth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ean")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ExtraOperatingTime")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GrossWeight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Guarantee")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ncm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NetWeight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Qty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SkuManufacturer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Unity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Sku");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
