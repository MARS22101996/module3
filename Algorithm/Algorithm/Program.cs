using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var dishes = new List<Dish>
            {
                new Dish
                {
                    Id = 1,
                    Name = "test1",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 10,
                    ProteinsPer100Grams = 60
                },
                new Dish
                {
                    Id = 2,
                    Name = "test2",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 25,
                    ProteinsPer100Grams = 45
                },
                new Dish
                {
                    Id = 3,
                    Name = "test3",
                    CarbohydratesPer100Grams = 50,
                    FatsPer100Grams = 20,
                    ProteinsPer100Grams = 30
                },
                new Dish
                {
                    Id = 4,
                    Name = "test4",
                    CarbohydratesPer100Grams = 50,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 20
                },
                new Dish
                {
                    Id = 5,
                    Name = "test5",
                    CarbohydratesPer100Grams = 80,
                    FatsPer100Grams = 10,
                    ProteinsPer100Grams = 10
                },
                new Dish
                {
                    Id = 6,
                    Name = "test6",
                    CarbohydratesPer100Grams = 65,
                    FatsPer100Grams = 20,
                    ProteinsPer100Grams = 15
                }
            };

            var limit = Console.ReadLine();
            var bp = new DietPlan(Convert.ToDouble(limit));

            //bp.MakeAllSets1(dishes);
            bp.MakeAllSets(dishes, DietStrategy.CarbohydrateBased);


            List<Dish> solve = bp.GetBestSet();


            if (!solve.Any())
            {
                Console.WriteLine("No solution!");
            }
            else
            {

                var sumC = solve.Sum(x => x.CarbohydratesPer100Grams);

                var sumF = solve.Sum(x => x.FatsPer100Grams);

                var sumP = solve.Sum(x => x.ProteinsPer100Grams);

                foreach (var item in solve)
                {
                    Console.WriteLine(
                        $"name {item.Name} C {item.CarbohydratesPer100Grams} F {item.FatsPer100Grams} P {item.ProteinsPer100Grams}");
                }


                Console.WriteLine(
                    $"Sum C {sumC} F {sumF} P {sumP}");
                Console.WriteLine("Solve");
            }
        }
    }
}
