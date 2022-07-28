using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebConsumoApi.Models
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

        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=DbProdutos;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__PRODUCTS__DDDF4BE68D1ADA23");

                entity.ToTable("PRODUTOS");

                entity.Property(e => e.Sku).HasColumnName("sku");

                entity.Property(e => e.IdItem)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_Item");

                entity.Property(e => e.NomeItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_Item");

                entity.Property(e => e.PrecoPor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("preco_por");

                entity.Property(e => e.QtdEstoque)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("qtd_Estoque");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
