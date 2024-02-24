using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class HealthyMealContext : IdentityDbContext<AppUser>
    {
        public HealthyMealContext()
        {
        }

        public HealthyMealContext(DbContextOptions<HealthyMealContext> options)
            : base(options)
        {
        }

        #region DbSets

        public virtual DbSet<Sex> Sexes { get; set; }

        public virtual DbSet<PhysicalActivityType> PhysicalActivityTypes { get; set; }

        public virtual DbSet<Meal> Meals { get; set; }

        public virtual DbSet<MealType> MealTypes { get; set; }

        public virtual DbSet<Units> Units { get; set; }

        public virtual DbSet<NutritionalValue> NutritionalValues { get; set; }

        public virtual DbSet<Food> Foods { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<ProductToBuy> ProductsToBuy { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<CookingStep> CookingSteps { get; set; }

        public virtual DbSet<MenuString> MenuStrings { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<MenuTemplate> MenuTemplates { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=DESKTOP-CN8UQ7K;Database=HealthyMealDb;Trusted_Connection=True;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.ToTable("Sexes");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhysicalActivityType>(entity =>
            {
                entity.ToTable("PhysicalActivityTypes");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("Meals");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.MealTypeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.NutritionalValueId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.NutritionalValue).WithMany(p => p.Meals)
                    .HasForeignKey(d => d.NutritionalValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meal_NutritionalValue");

                entity.HasOne(d => d.MealType).WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meal_MealType");

                entity.HasOne(d => d.AppUser).WithMany(p => p.Meals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meal_AppUser");
            });

            modelBuilder.Entity<MealType>(entity =>
            {
                entity.ToTable("MealTypes");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NutritionalValue>(entity =>
            {
                entity.ToTable("NutritionalValues");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food).WithMany(p => p.NutritionalValues)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NutritionalValue_Food");

                entity.HasOne(d => d.Units).WithMany(p => p.NutritionalValues)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NutritionalValue_Units");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.ToTable("Units");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Foods");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Food).WithMany(p => p.Products)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Food");

                entity.HasOne(d => d.AppUser).WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_AppUser");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipes");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CookingTime).HasColumnType("time");

                entity.HasOne(d => d.Food).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Food");

                entity.HasOne(d => d.MealType).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.MealTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_MealType");

                entity.HasOne(d => d.AppUser).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_AppUser");
            });

            modelBuilder.Entity<ProductToBuy>(entity =>
            {
                entity.ToTable("ProductsToBuy");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductsToBuy)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductToBuy_Product");

                entity.HasOne(d => d.Units).WithMany(p => p.ProductsToBuy)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductToBuy_Units");

                entity.HasOne(d => d.AppUser).WithMany(p => p.ProductsToBuy)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductToBuy_AppUser");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredients");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Product");

                entity.HasOne(d => d.Recipe).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Recipe");

                entity.HasOne(d => d.Units).WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Units");
            });

            modelBuilder.Entity<CookingStep>(entity =>
            {
                entity.ToTable("CookingSteps");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe).WithMany(p => p.CookingSteps)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CookingStep_Recipe");
            });

            modelBuilder.Entity<MenuString>(entity =>
            {
                entity.ToTable("MenuStrings");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.MealTypeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu).WithMany(p => p.MenuStrings)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuString_Menu");

                entity.HasOne(d => d.Recipe).WithMany(p => p.MenuStrings)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuString_Recipe");

                entity.HasOne(d => d.MealType).WithMany(p => p.MenuStrings)
                    .HasForeignKey(d => d.MealTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuString_MealType");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menus");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.AppUser).WithMany(p => p.Menus)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_AppUser");
            });

            modelBuilder.Entity<MenuTemplate>(entity =>
            {
                entity.ToTable("MenuTemplates");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu).WithMany(p => p.MenuTemplates)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuTemplate_Menu");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUsers");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.SexId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalActivityId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sex).WithMany(p => p.Users)
                    .HasForeignKey(d => d.SexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppUser_Sex");

                entity.HasOne(d => d.PhysicalActivity).WithMany(p => p.Users)
                    .HasForeignKey(d => d.PhysicalActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppUser_PhysicalActivity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
