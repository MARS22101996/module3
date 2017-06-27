using System;
using DietAssistant.Entities;
using System.Collections.Generic;
using DietAssistant.BLL.Dto;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.Tests.Infrastructure
{
    public class ReportDataClass
    {
        public UserDto User => new UserDto {Id = 1};

        public IEnumerable<Dish> GetDishes
        {
            get
            {
                yield return new Dish
                {
                    CarbohydratesPer100Grams = 9,
                    FatsPer100Grams = 9,
                    ProteinsPer100Grams = 35
                };
                yield return new Dish
                {
                    CarbohydratesPer100Grams = 60,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 30
                };
            }
        }

        public IEnumerable<DishDto> GetDishesForDiet
        {
            get
            {
                yield return new DishDto
                {
                    Id = 1,
                    Name = "test1",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 10,
                    ProteinsPer100Grams = 60
                };
                yield return new DishDto
                {
                    Id = 2,
                    Name = "test2",
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 25,
                    ProteinsPer100Grams = 45
                };
                yield return new DishDto
                {
                    Id = 3,
                    Name = "test3",
                    CarbohydratesPer100Grams = 50,
                    FatsPer100Grams = 20,
                    ProteinsPer100Grams = 30
                };
                yield return new DishDto
                {
                    Id = 4,
                    Name = "test4",
                    CarbohydratesPer100Grams = 50,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 20
                };
                yield return new DishDto
                {
                    Id = 5,
                    Name = "test5",
                    CarbohydratesPer100Grams = 80,
                    FatsPer100Grams = 10,
                    ProteinsPer100Grams = 10
                };
                yield return new DishDto
                {
                    Id = 6,
                    Name = "test6",
                    CarbohydratesPer100Grams = 65,
                    FatsPer100Grams = 20,
                    ProteinsPer100Grams = 15
                };
            }
        }

        public IEnumerable<Report> Reports
        {
            get
            {
                yield return new Report {Carbohydrates = 10, Fats = 20, Proteins = 30};
                yield return new Report {Carbohydrates = 30, Fats = 20, Proteins = 10};
            }
        }

        public IEnumerable<Report> GetReportsByDay(DateTime date)
        {
            var reportsByDate = new List<Report> {new Report(), new Report()};
            return reportsByDate;
        }

        public IEnumerable<UserDish> GetUserDishes(List<Dish> dishes, DateTime date, int userId)
        {
            var dishesOfUser = new List<UserDish>
            {
                new UserDish
                {
                    Date = date,
                    Dish = dishes[0],
                    Grams = 200,
                    UserId = userId,
                },
                new UserDish
                {
                    Date = date,
                    Dish = dishes[1],
                    Grams = 200,
                    UserId = userId
                }
            };
            return dishesOfUser;
        }

        public IEnumerable<UserDish> GetUserDishesWithViolations(List<Dish> dishes, DateTime date, int userId)
        {
            var dishesOfUser = new List<UserDish>
            {
                new UserDish
                {
                    Date = date,
                    Dish = dishes[0],
                    Grams = 100,
                    UserId = userId,
                }
            };
            return dishesOfUser;
        }

        public IEnumerable<Report> GetReportsWithType(DateTime date, BodyType bodyType)
        {
            var reports = new List<Report>
            {
                new Report
                {
                    Date = date,
                    Carbohydrates = 10,
                    Fats = 20,
                    Proteins = 30,
                    User = new User {Type = bodyType}
                },
                new Report
                {
                    Date = date,
                    Carbohydrates = 30,
                    Fats = 20,
                    Proteins = 10,
                    User = new User {Type = bodyType}
                }
            };
            return reports;
        }
    }
}
