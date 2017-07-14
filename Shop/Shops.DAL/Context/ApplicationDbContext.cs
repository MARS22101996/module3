using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shops.DAL.Entities;

namespace Shops.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=CDPDatabase", throwIfV1Schema: false)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
