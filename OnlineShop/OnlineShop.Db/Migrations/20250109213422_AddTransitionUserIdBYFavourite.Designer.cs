﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250109213422_AddTransitionUserIdBYFavourite")]
    partial class AddTransitionUserIdBYFavourite
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Comparison", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransitionUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comparisons");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favourite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransitionUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagesPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageId = new Guid("bb395983-de55-4bec-b4d7-0969888f7d63"),
                            ImagesPath = "/Images/Кухня_Сормово.png",
                            ProductId = new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2")
                        },
                        new
                        {
                            ImageId = new Guid("5ad7bb8a-e78b-40c2-944b-daf2b16f8bf3"),
                            ImagesPath = "/Images/Шкаф.jpg",
                            ProductId = new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2")
                        },
                        new
                        {
                            ImageId = new Guid("60f6280a-b32e-4fec-8887-24f9f2116e47"),
                            ImagesPath = "/Images/спальни.jpg",
                            ProductId = new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2")
                        },
                        new
                        {
                            ImageId = new Guid("4a3bbf96-eb2e-4dda-a7c9-9afb14fe6351"),
                            ImagesPath = "/Images/Кухня_Сормово.png",
                            ProductId = new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0")
                        },
                        new
                        {
                            ImageId = new Guid("3cc2692b-ed03-4a64-98b6-a89a0b76d14b"),
                            ImagesPath = "/Images/Шкаф.jpg",
                            ProductId = new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0")
                        },
                        new
                        {
                            ImageId = new Guid("1d9b8692-74a4-4b5d-8db4-40ea1976e5b6"),
                            ImagesPath = "/Images/спальни.jpg",
                            ProductId = new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0")
                        },
                        new
                        {
                            ImageId = new Guid("4a1493e5-8f6b-4913-abb3-501aa4c45aab"),
                            ImagesPath = "/Images/Кухня_Сормово.png",
                            ProductId = new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c")
                        },
                        new
                        {
                            ImageId = new Guid("635a9067-6472-4efa-9438-a742b02a2bc4"),
                            ImagesPath = "/Images/Шкаф.jpg",
                            ProductId = new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c")
                        },
                        new
                        {
                            ImageId = new Guid("4a7b2ece-5706-4d2e-804b-fedea140964f"),
                            ImagesPath = "/Images/спальни.jpg",
                            ProductId = new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c")
                        },
                        new
                        {
                            ImageId = new Guid("c5ae8c47-024e-4037-badf-1bffef1dffca"),
                            ImagesPath = "/Images/Кухня_Сормово.png",
                            ProductId = new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15")
                        },
                        new
                        {
                            ImageId = new Guid("de8c4cb1-a702-4fb0-a09c-e5ca2d35eddb"),
                            ImagesPath = "/Images/Шкаф.jpg",
                            ProductId = new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15")
                        },
                        new
                        {
                            ImageId = new Guid("94b8cdb9-fe8f-4e4e-afa5-b47fb70197ad"),
                            ImagesPath = "/Images/спальни.jpg",
                            ProductId = new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15")
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ComparisonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cost")
                        .HasPrecision(9, 2)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)");

                    b.Property<Guid?>("FavouriteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ComparisonId");

                    b.HasIndex("FavouriteId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2"),
                            Category = "Кухни",
                            Cost = 127900,
                            Description = "Авторское удобство для каждодневного использования",
                            Grade = 0.0,
                            Name = "Мария"
                        },
                        new
                        {
                            Id = new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15"),
                            Category = "Шкафы",
                            Cost = 49900,
                            Description = "Уникальное удобство хранения Ваших вещей",
                            Grade = 0.0,
                            Name = "Венге"
                        },
                        new
                        {
                            Id = new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c"),
                            Category = "Детская мебель",
                            Cost = 179900,
                            Description = "Уютная обстановка для детей",
                            Grade = 0.0,
                            Name = "Счастье"
                        },
                        new
                        {
                            Id = new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0"),
                            Category = "Спальни",
                            Cost = 99900,
                            Description = "Комфорт Вашего отдыха",
                            Grade = 0.0,
                            Name = "Пушка"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TransitionUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Comparison", null)
                        .WithMany("ComparisonProducts")
                        .HasForeignKey("ComparisonId");

                    b.HasOne("OnlineShop.Db.Models.Favourite", null)
                        .WithMany("FavouriteProducts")
                        .HasForeignKey("FavouriteId");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Rating", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithOne("Rating")
                        .HasForeignKey("OnlineShop.Db.Models.Rating", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Review", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Comparison", b =>
                {
                    b.Navigation("ComparisonProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favourite", b =>
                {
                    b.Navigation("FavouriteProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Rating")
                        .IsRequired();

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
