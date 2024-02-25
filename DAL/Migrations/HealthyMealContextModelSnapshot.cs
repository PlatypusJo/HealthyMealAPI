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

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<double>("KcalAmountGoal")
                        .HasColumnType("float");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("NormalKcalAmount")
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

                    b.Property<string>("PhysicalActivityId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SexId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PhysicalActivityId");

                    b.HasIndex("SexId");

                    b.ToTable("AppUsers", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.CookingStep", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("CookingSteps", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Food", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Foods", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<double>("UnitsAmount")
                        .HasColumnType("float");

                    b.Property<string>("UnitsId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UnitsId");

                    b.ToTable("Ingredients", (string)null);
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

                    b.ToTable("Meals", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.MealType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MealTypes", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Menu", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<double>("Kcal")
                        .HasColumnType("float");

                    b.Property<double>("Proteins")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.MenuString", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("MealTypeId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("MenuId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MealTypeId");

                    b.HasIndex("MenuId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MenuStrings", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.MenuTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("MenuId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuTemplates", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.NutritionalValue", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

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

                    b.Property<double>("UnitsAmount")
                        .HasColumnType("float");

                    b.Property<string>("UnitsId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UnitsId");

                    b.ToTable("NutritionalValues", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.PhysicalActivityType", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<double>("CoeffValue")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PhysicalActivityTypes", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("FoodId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("UserId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.ProductToBuy", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsBought")
                        .HasColumnType("bit");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<double>("UnitsAmount")
                        .HasColumnType("float");

                    b.Property<string>("UnitsId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitsId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductsToBuy", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Recipe", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<TimeSpan>("CookingTime")
                        .HasColumnType("time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("FoodId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MealTypeId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("MealTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Sex", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .IsUnicode(false)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Sexes", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Units", b =>
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

                    b.ToTable("Units", (string)null);
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

            modelBuilder.Entity("DAL.Entities.AppUser", b =>
                {
                    b.HasOne("DAL.Entities.PhysicalActivityType", "PhysicalActivity")
                        .WithMany("Users")
                        .HasForeignKey("PhysicalActivityId")
                        .IsRequired()
                        .HasConstraintName("FK_AppUser_PhysicalActivity");

                    b.HasOne("DAL.Entities.Sex", "Sex")
                        .WithMany("Users")
                        .HasForeignKey("SexId")
                        .IsRequired()
                        .HasConstraintName("FK_AppUser_Sex");

                    b.Navigation("PhysicalActivity");

                    b.Navigation("Sex");
                });

            modelBuilder.Entity("DAL.Entities.CookingStep", b =>
                {
                    b.HasOne("DAL.Entities.Recipe", "Recipe")
                        .WithMany("CookingSteps")
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("FK_CookingStep_Recipe");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("DAL.Entities.Ingredient", b =>
                {
                    b.HasOne("DAL.Entities.Product", "Product")
                        .WithMany("Ingredients")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Ingredient_Product");

                    b.HasOne("DAL.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("FK_Ingredient_Recipe");

                    b.HasOne("DAL.Entities.Units", "Units")
                        .WithMany("Ingredients")
                        .HasForeignKey("UnitsId")
                        .IsRequired()
                        .HasConstraintName("FK_Ingredient_Units");

                    b.Navigation("Product");

                    b.Navigation("Recipe");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("DAL.Entities.Meal", b =>
                {
                    b.HasOne("DAL.Entities.MealType", "MealType")
                        .WithMany("Meals")
                        .HasForeignKey("MealTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Meal_MealType");

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

            modelBuilder.Entity("DAL.Entities.Menu", b =>
                {
                    b.HasOne("DAL.Entities.AppUser", "AppUser")
                        .WithMany("Menus")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Menu_AppUser");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("DAL.Entities.MenuString", b =>
                {
                    b.HasOne("DAL.Entities.MealType", "MealType")
                        .WithMany("MenuStrings")
                        .HasForeignKey("MealTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuString_MealType");

                    b.HasOne("DAL.Entities.Menu", "Menu")
                        .WithMany("MenuStrings")
                        .HasForeignKey("MenuId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuString_Menu");

                    b.HasOne("DAL.Entities.Recipe", "Recipe")
                        .WithMany("MenuStrings")
                        .HasForeignKey("RecipeId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuString_Recipe");

                    b.Navigation("MealType");

                    b.Navigation("Menu");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("DAL.Entities.MenuTemplate", b =>
                {
                    b.HasOne("DAL.Entities.Menu", "Menu")
                        .WithMany("MenuTemplates")
                        .HasForeignKey("MenuId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuTemplate_Menu");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("DAL.Entities.NutritionalValue", b =>
                {
                    b.HasOne("DAL.Entities.Food", "Food")
                        .WithMany("NutritionalValues")
                        .HasForeignKey("FoodId")
                        .IsRequired()
                        .HasConstraintName("FK_NutritionalValue_Food");

                    b.HasOne("DAL.Entities.Units", "Units")
                        .WithMany("NutritionalValues")
                        .HasForeignKey("UnitsId")
                        .IsRequired()
                        .HasConstraintName("FK_NutritionalValue_Units");

                    b.Navigation("Food");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("DAL.Entities.Product", b =>
                {
                    b.HasOne("DAL.Entities.Food", "Food")
                        .WithMany("Products")
                        .HasForeignKey("FoodId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Food");

                    b.HasOne("DAL.Entities.AppUser", "AppUser")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_AppUser");

                    b.Navigation("AppUser");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("DAL.Entities.ProductToBuy", b =>
                {
                    b.HasOne("DAL.Entities.Product", "Product")
                        .WithMany("ProductsToBuy")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductToBuy_Product");

                    b.HasOne("DAL.Entities.Units", "Units")
                        .WithMany("ProductsToBuy")
                        .HasForeignKey("UnitsId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductToBuy_Units");

                    b.HasOne("DAL.Entities.AppUser", "AppUser")
                        .WithMany("ProductsToBuy")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductToBuy_AppUser");

                    b.Navigation("AppUser");

                    b.Navigation("Product");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("DAL.Entities.Recipe", b =>
                {
                    b.HasOne("DAL.Entities.Food", "Food")
                        .WithMany("Recipes")
                        .HasForeignKey("FoodId")
                        .IsRequired()
                        .HasConstraintName("FK_Recipe_Food");

                    b.HasOne("DAL.Entities.MealType", "MealType")
                        .WithMany("Recipes")
                        .HasForeignKey("MealTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Recipe_MealType");

                    b.HasOne("DAL.Entities.AppUser", "AppUser")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Recipe_AppUser");

                    b.Navigation("AppUser");

                    b.Navigation("Food");

                    b.Navigation("MealType");
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

                    b.Navigation("Menus");

                    b.Navigation("Products");

                    b.Navigation("ProductsToBuy");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("DAL.Entities.Food", b =>
                {
                    b.Navigation("NutritionalValues");

                    b.Navigation("Products");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("DAL.Entities.MealType", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("MenuStrings");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("DAL.Entities.Menu", b =>
                {
                    b.Navigation("MenuStrings");

                    b.Navigation("MenuTemplates");
                });

            modelBuilder.Entity("DAL.Entities.NutritionalValue", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("DAL.Entities.PhysicalActivityType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.Entities.Product", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("ProductsToBuy");
                });

            modelBuilder.Entity("DAL.Entities.Recipe", b =>
                {
                    b.Navigation("CookingSteps");

                    b.Navigation("Ingredients");

                    b.Navigation("MenuStrings");
                });

            modelBuilder.Entity("DAL.Entities.Sex", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.Entities.Units", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("NutritionalValues");

                    b.Navigation("ProductsToBuy");
                });
#pragma warning restore 612, 618
        }
    }
}
