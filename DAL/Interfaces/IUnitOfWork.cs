using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository<AppUser> AppUsers { get; }
        IRepository<Sex> Sexes { get; }
        IRepository<PhysicalActivityType> PhysicalActivityTypes { get; }
        IRepository<Meal> Meals { get; }
        IRepository<MealType> MealTypes { get; }
        IRepository<Food> Foods { get; }
        IRepository<Recipe> Recipes { get; }
        IRepository<NutritionalValue> NutritionalValues { get; }
        IRepository<Units> Units { get; }
        IRepository<ProductToBuy> ProductsToBuy { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<CookingStep> CookingSteps { get; }
        IRepository<MenuString> MenuStrings { get; }
        IRepository<Menu> Menus { get; }


        /// <summary>
        ///     Сохраняет изменения в бд
        /// </summary>
        /// <returns>
        ///     При успешном выполнени возвращает количество
        ///     записей состояния, записанных в базу данных.
        ///     Иначе возвращает минимальное значение Int32.
        /// </returns>
        Task<int> Save();
    }
}
