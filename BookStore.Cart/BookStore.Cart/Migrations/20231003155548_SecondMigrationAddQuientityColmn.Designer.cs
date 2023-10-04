﻿// <auto-generated />
using BookStore.Cart.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Cart.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20231003155548_SecondMigrationAddQuientityColmn")]
    partial class SecondMigrationAddQuientityColmn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookStore.Cart.Repository.CartEntity", b =>
                {
                    b.Property<long>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CartId"), 1L, 1);

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPurchesed")
                        .HasColumnType("bit");

                    b.Property<int>("Quntity")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}