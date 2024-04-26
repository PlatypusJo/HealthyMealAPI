using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthyMealContext _db;

        public UnitOfWork(IConfiguration configuration)
        {
            _db = new HealthyMealContext(configuration);
        }

        public IUserRepository<AppUser> AppUsers => throw new NotImplementedException();

        public IRepository<Sex> Sexes => throw new NotImplementedException();

        public IRepository<PhysicalActivityType> PhysicalActivityTypes => throw new NotImplementedException();

        public IRepository<Meal> Meals => throw new NotImplementedException();

        public IRepository<MealType> MealTypes => throw new NotImplementedException();

        public IRepository<Food> Foods => throw new NotImplementedException();

        public IRepository<Recipe> Recipes => throw new NotImplementedException();

        public IRepository<NutritionalValue> NutritionalValues => throw new NotImplementedException();

        public IRepository<Units> Units => throw new NotImplementedException();

        public IRepository<ProductToBuy> ProductsToBuy => throw new NotImplementedException();

        public IRepository<Ingredient> Ingredients => throw new NotImplementedException();

        public IRepository<CookingStep> CookingSteps => throw new NotImplementedException();

        public IRepository<MenuString> MenuStrings => throw new NotImplementedException();

        public IRepository<Menu> Menus => throw new NotImplementedException();

        public async Task<int> Save()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
