using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Data
{
    public static class DbInitializer
    {
        /// <summary>
        /// Создает и настраивает роли с помощью IdentityRole.
        /// </summary>
        /// <param name="serviceProvider">Экземпляр служебного класса IServiceProvider, который помогает в обслуживании другим объектам.</param>
        /// <returns></returns>
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            // Создание Администратора
            string adminLogin = "Admin";
            string adminName = "Admin";
            string adminPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(adminLogin) == null)
            {
                AppUser admin = new AppUser { Login = adminLogin, UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            // Создание Пользователя
            string userLogin = "Vasya";
            string userName = "Михаил";
            string userPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(userLogin) == null)
            {
                AppUser user = new AppUser { Login = userLogin, UserName = userName };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
