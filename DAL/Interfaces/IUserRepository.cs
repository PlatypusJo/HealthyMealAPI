﻿using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository<T> where T : IdentityUser<string>
    {
        Task<List<T>> GetAll(UserManager<AppUser> userManager);

        Task<T> GetItem(string login, UserManager<T> userManager);
        Task<IdentityResult> Create(T item, string password, UserManager<T> userManager);
        Task<IdentityResult> Update(T item, UserManager<T> userManager);
        Task<IdentityResult> Delete(string login, UserManager<T> userManager);
        Task<bool> Exists(string login, UserManager<T> userManager);

        Task<List<IdentityRole<int>>> GetUserRoles(AppUser item);
    }
}
