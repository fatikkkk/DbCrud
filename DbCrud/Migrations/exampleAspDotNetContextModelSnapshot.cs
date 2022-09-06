﻿// <auto-generated />
using DbCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbCrud.Migrations
{
    [DbContext(typeof(exampleAspDotNetContext))]
    partial class exampleAspDotNetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DbCrud.Models.Category", b =>
                {
                    b.Property<string>("CatCode")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength(true);

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CatCode")
                        .HasName("PK__Categori__5E593E4F46313D2C");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DbCrud.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CustomerID");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DbCrud.Models.Product", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength(true);

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Code")
                        .HasName("PK__Products__A25C5AA6CFA68C97");

                    b.HasIndex("Category");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DbCrud.Models.Product", b =>
                {
                    b.HasOne("DbCrud.Models.Category", "CategoryNavigation")
                        .WithMany("Products")
                        .HasForeignKey("Category")
                        .HasConstraintName("FKCategoriesToProducts")
                        .IsRequired();

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("DbCrud.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
