﻿// <auto-generated />
using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(HealthyMealContext))]
    partial class HealthyMealContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

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

                    b.Property<double>("KcalGoal")
                        .HasColumnType("float");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("NormalKcal")
                        .HasColumnType("float");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("AppUser", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Meal", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<double>("AmountEaten")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("MealTypeId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("NutritionalValueId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MealTypeId");

                    b.HasIndex("NutritionalValueId");

                    b.HasIndex("UserId");

                    b.ToTable("Meal", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.MealType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MealType", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.NutritionalValue", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("FoodId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<double>("Kcal")
                        .HasColumnType("float");

                    b.Property<double>("Proteins")
                        .HasColumnType("float");

                    b.Property<string>("UnitsId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.ToTable("NutritionalValue", (string)null);
                });

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
                        .HasColumnType("varchar(450)");

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
                        .HasColumnType("varchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Meal", b =>
                {
                    b.HasOne("DAL.Entities.MealType", "MealType")
                        .WithMany("Meals")
                        .HasForeignKey("MealTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Meal_MealTypeId");

                    b.HasOne("DAL.Entities.NutritionalValue", "NutritionalValue")
                        .WithMany("Meals")
                        .HasForeignKey("NutritionalValueId")
                        .IsRequired()
                        .HasConstraintName("FK_Meal_NutritionalValue");

                    b.HasOne("DAL.Entities.AppUser", "AppUser")
                        .WithMany("Meals")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Meal_AppUser");

                    b.Navigation("AppUser");

                    b.Navigation("MealType");

                    b.Navigation("NutritionalValue");
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
                    b.HasOne("DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Entities.AppUser", null)
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

                    b.HasOne("DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.AppUser", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("DAL.Entities.MealType", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("DAL.Entities.NutritionalValue", b =>
                {
                    b.Navigation("Meals");
                });
#pragma warning restore 612, 618
        }
    }
}