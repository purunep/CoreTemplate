﻿// <auto-generated />
using System;
using CoreTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreTest.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20181001002529_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreTest.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, OrderDate = new DateTime(2018, 9, 30, 20, 25, 29, 114, DateTimeKind.Local), OrderNumber = "12345" }
                    );
                });

            modelBuilder.Entity("CoreTest.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("CoreTest.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtDating");

                    b.Property<string>("ArtDescription");

                    b.Property<string>("ArtId");

                    b.Property<string>("Artist");

                    b.Property<DateTime>("ArtistBirthDate");

                    b.Property<DateTime>("ArtistDeathDate");

                    b.Property<string>("ArtistNationality");

                    b.Property<string>("Category");

                    b.Property<decimal>("Price");

                    b.Property<string>("Size");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoreTest.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("CoreTest.Data.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("CoreTest.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
