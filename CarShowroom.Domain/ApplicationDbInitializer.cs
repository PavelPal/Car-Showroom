using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarShowroom.Domain
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole {Name = "Admin"};
            var userRole = new IdentityRole {Name = "User"};

            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            var admin = new ApplicationUser {Email = "admin@admin.com", UserName = "admin@admin.com"};
            var password = "Aaa123!";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }

            base.Seed(context);
        }
    }
}