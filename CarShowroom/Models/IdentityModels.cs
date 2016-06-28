using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CarShowroom.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarShowroom.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Review> Reviews { get; set; }
        public List<Order> Orders { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public IDbSet<BodyType> BodyTypes { get; set; }
        public IDbSet<Brand> Brands { get; set; }
        public IDbSet<Engine> Engines { get; set; }
        public IDbSet<Car> Cars { get; set; }
        public IDbSet<CarType> CarTypes { get; set; }
        public IDbSet<DriveUnit> DriveUnits { get; set; }
        public IDbSet<Headlight> Headlights { get; set; }
        public IDbSet<CarImage> CarImages { get; set; }
        public IDbSet<Transmission> Transmissions { get; set; }
        public IDbSet<Order> Orders { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}