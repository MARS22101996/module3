using System.Data.Entity;
using DietAssistant.Entities;

namespace DietAssistant.Context
{
    public class DietAssistantContext : DbContext
    {
        static DietAssistantContext()
        {
            Database.SetInitializer(new DietDbInitializer());
        }

        public DietAssistantContext()
        {
        }

        public DietAssistantContext(string connectionString)
            : base("name=CDPDatabase")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Dish> Dishes { get; set; }

        public virtual DbSet<Report> Reports { get; set; }

        public virtual DbSet<UserDish> UserDishes { get; set; }

    }
}