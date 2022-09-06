using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DbCrud.Models;

#nullable disable

namespace DbCrud.Data
{
    public partial class exampleAspDotNetContext : DbContext
    {
        public exampleAspDotNetContext()
        {
        }

        public exampleAspDotNetContext(DbContextOptions<exampleAspDotNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatCode)
                    .HasName("PK__Categori__5E593E4F46313D2C");

                entity.Property(e => e.CatCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CatName).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Products__A25C5AA6CFA68C97");

                entity.Property(e => e.Category)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCategoriesToProducts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
