using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietAssistant.Entities;

namespace DietAssistant.Context
{
    public class DietDbInitializer : DropCreateDatabaseAlways<DietAssistantContext>
    {
        protected override void Seed(DietAssistantContext db)
        {
            var dishes = AssignDishes();

            db.Dishes.AddRange(dishes);
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

    }
}

