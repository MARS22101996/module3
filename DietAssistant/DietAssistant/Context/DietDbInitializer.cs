using System;
using System.Collections.Generic;
using System.Data.Entity;
using DietAssistant.Entities;
using DietAssistant.Core.Enums;

namespace DietAssistant.Context
{
    public class DietDbInitializer : DropCreateDatabaseAlways<DietAssistantContext>
    {
        protected override void Seed(DietAssistantContext db)
        {
            var dishes = AssignDishes();

            var users = AssignUsers();

            db.Dishes.AddRange(dishes);

            db.Users.AddRange(users);

            db.SaveChanges();

            var dish = db.Dishes.Find(1);

            var user = db.Users.Find(1);

            var userDishes = AssignUserDishes(dish, user);

            var reports = AssignReports();

            db.Reports.AddRange(reports);
        }

        private static List<User> AssignUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "test-name",
                    LastName = "test-last-name",
                    Email = "test@mail.ru",
                    Type = BodyType.Ectomorph
                }
            };
        }

        private static List<Dish> AssignDishes()
        {
            return new List<Dish>
            {
                new Dish
                {
                    Id = 1,
                    Name = "test1",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 30
                },
                new Dish
                {
                    Id = 2,
                    Name = "test2",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 30
                },
                new Dish
                {
                    Id = 3,
                    Name = "test3",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 30
                },
            };
        }

        private static List<Report> AssignReports()
        {
            return new List<Report>
            {
                new Report
                {
                    Id = 1,
                    Date = DateTime.UtcNow,
                    UserId=1,
                    Carbohydrates = 20,
                    Fats = 30,
                    Proteins = 40
                }
            };
        }

        private static List<UserDish> AssignUserDishes(Dish dish, User user)
        {
            return new List<UserDish>
            {
                new UserDish
                {
                    Date = DateTime.UtcNow,
                    Dish = dish,
                    Grams = 200,
                    UserId = user.Id,
                    User = user,
                    DishId = dish.Id
                },
                new UserDish
                {
                    Date = DateTime.UtcNow,
                    Dish = dish,
                    Grams = 200,
                    UserId = user.Id,
                    User = user,
                    DishId = dish.Id
                }
            };
        }
    }
}