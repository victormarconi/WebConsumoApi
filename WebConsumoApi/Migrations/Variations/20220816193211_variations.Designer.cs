﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebConsumoApi.DBContext;

#nullable disable

namespace WebConsumoApi.Migrations.Variations
{
    [DbContext(typeof(VariationsContext))]
    [Migration("20220816193211_variations")]
    partial class variations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebConsumoApi.Models.VariationsDB+Product_Variations", b =>
                {
                    b.Property<string>("sku")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("EAN")
                        .HasColumnType("longtext");

                    b.Property<string>("color")
                        .HasColumnType("longtext");

                    b.Property<string>("images")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("qty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("sabor")
                        .HasColumnType("longtext");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("sku_pai")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("tamanho")
                        .HasColumnType("longtext");

                    b.Property<string>("voltagem")
                        .HasColumnType("longtext");

                    b.HasKey("sku");

                    b.ToTable("Variations");
                });
#pragma warning restore 612, 618
        }
    }
}
