﻿// <auto-generated />
using System;
using BackendTeamwork.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240503154901_db-init")]
    partial class dbinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackendTeamwork.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address_line");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip");

                    b.HasKey("Id")
                        .HasName("pk_address");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uuid")
                        .HasColumnName("payment_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasIndex("PaymentId")
                        .HasDatabaseName("ix_order_payment_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_order_user_id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.OrderStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uuid")
                        .HasColumnName("stock_id");

                    b.HasKey("Id")
                        .HasName("pk_order_stock");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_stock_order_id");

                    b.HasIndex("StockId")
                        .HasDatabaseName("ix_order_stock_stock_id");

                    b.ToTable("order_stock", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Method")
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_payment");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_payment_user_id");

                    b.ToTable("payment", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
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

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_product_category_id");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_review");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_review_product_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_review_user_id");

                    b.ToTable("review", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("size");

                    b.HasKey("Id")
                        .HasName("pk_stock");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_stock_product_id");

                    b.ToTable("stock", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<Guid>("AddressId1")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id1");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<Guid>("Wishlist")
                        .HasColumnType("uuid")
                        .HasColumnName("wishlist");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("AddressId1")
                        .HasDatabaseName("ix_user_address_id1");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("userid")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_wishlist");

                    b.ToTable("wishlist", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Order", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Payment", null)
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_payment_payment_id");

                    b.HasOne("BackendTeamwork.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_user_user_id");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.OrderStock", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Order", "Order")
                        .WithMany("OrderStocks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_stock_order_order_id");

                    b.HasOne("BackendTeamwork.Entities.Stock", null)
                        .WithMany("OrderStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_stock_stock_stock_id");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Payment", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.User", null)
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payment_user_user_id");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Product", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_category_category_id");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Review", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Product", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_review_product_product_id");

                    b.HasOne("BackendTeamwork.Entities.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_review_user_user_id");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Stock", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Product", null)
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stock_product_product_id");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.User", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_address_address_id1");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Order", b =>
                {
                    b.Navigation("OrderStocks");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Product", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Stock", b =>
                {
                    b.Navigation("OrderStocks");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
