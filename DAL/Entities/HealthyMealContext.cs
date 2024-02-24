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

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<NutritionalValue> NutritionalValues { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=DESKTOP-CN8UQ7K;Database=HealthyMealDb;Trusted_Connection=True;Encrypt=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("Meal");

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
                    .HasConstraintName("FK_Meal_MealTypeId");

                entity.HasOne(d => d.AppUser).WithMany(p => p.Meals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meal_AppUser");
            });

            modelBuilder.Entity<MealType>(entity =>
            {
                entity.ToTable("MealType");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NutritionalValue>(entity =>
            {
                entity.ToTable("NutritionalValue");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UnitsId)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
