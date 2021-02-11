using CmsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsStore.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDBContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async void Initialize()
        {
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }

            if (_db.Roles.Any(r => r.Name == "admin")) return;

            _roleManager.CreateAsync(new IdentityRole("admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("editor")).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            }, "admin").GetAwaiter().GetResult();

            ApplicationUser user = await _db.Users.Where(u => u.Email == "admin@gmail.com").FirstOrDefaultAsync();

            await _userManager.AddToRoleAsync(user, "admin");
        }        

    }
}
