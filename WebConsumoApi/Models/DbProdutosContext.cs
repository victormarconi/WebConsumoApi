using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebConsumoApi.Models;

namespace WebConsumoApi.ViewModels
{
    public partial class DbProdutosContext : DbContext
    {
        public DbProdutosContext()
        {
        }

        public DbProdutosContext(DbContextOptions<DbProdutosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProdutoDB> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; DataBase=DbProdutos;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoDB>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__PRODUCTS__DDDF4BE68D1ADA23");

                entity.ToTable("PRODUTOS");

                entity.Property(e => e.Sku)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sku");

                entity.Property(e => e.Active)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .HasDefaultValueSql("('enabled')");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Depth)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("depth");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Ean)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ean");

                entity.Property(e => e.ExtraOperatingTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("extra_operating_time");

                entity.Property(e => e.GrossWeight)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gross_weight");

                entity.Property(e => e.Guarantee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("guarantee");

                entity.Property(e => e.Height)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("height");

                entity.Property(e => e.Images)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("images");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Ncm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ncm");

                entity.Property(e => e.NetWeight)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("net_weight");

                entity.Property(e => e.Origin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("origin");

                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.Qty)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("qty");

                entity.Property(e => e.SkuManufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sku_manufacturer");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Unity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unity");

                entity.Property(e => e.Width)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("width");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}