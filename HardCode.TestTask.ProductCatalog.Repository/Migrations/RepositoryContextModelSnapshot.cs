﻿// <auto-generated />
using HardCode.TestTask.ProductCatalog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HardCode.TestTask.ProductCatalog.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("attribute_type_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AttributeTypeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("attribute");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.AttributeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("attribute_type");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("decimal");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.ProductCategoryAttribute", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("AttributeId")
                        .HasColumnType("integer")
                        .HasColumnName("attribute_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("ProductId", "AttributeId");

                    b.HasIndex("AttributeId");

                    b.ToTable("product_category_attribute");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Attribute", b =>
                {
                    b.HasOne("HardCode.TestTask.ProductCatalog.Entities.Models.AttributeType", "Type")
                        .WithMany("Attributes")
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HardCode.TestTask.ProductCatalog.Entities.Models.Category", "Category")
                        .WithMany("Attributes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Product", b =>
                {
                    b.HasOne("HardCode.TestTask.ProductCatalog.Entities.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.ProductCategoryAttribute", b =>
                {
                    b.HasOne("HardCode.TestTask.ProductCatalog.Entities.Models.Attribute", "Attribute")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HardCode.TestTask.ProductCatalog.Entities.Models.Product", "Product")
                        .WithMany("Attributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Attribute", b =>
                {
                    b.Navigation("ProductAttributes");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.AttributeType", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Category", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("HardCode.TestTask.ProductCatalog.Entities.Models.Product", b =>
                {
                    b.Navigation("Attributes");
                });
#pragma warning restore 612, 618
        }
    }
}