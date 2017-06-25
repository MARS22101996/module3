using System;
using DietAssistant.Entities;
using System.Collections.Generic;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.Tests.Infrastructure
{
    public class ReportDataClass
    {
        public UserDto User => new UserDto { Id = 1 };

        public IEnumerable<Dish> GetDishes
        {
            get
            {
                yield return new Dish
                {
                    CarbohydratesPer100Grams = 9,
                    FatsPer100Grams = 9,
                    ProteinsPer100Grams = 9
                };
                yield return new Dish
                {
                    CarbohydratesPer100Grams = 30,
                    FatsPer100Grams = 30,
                    ProteinsPer100Grams = 30
                };
            }
        }

        public IEnumerable<Report> Reports
        {
            get
            {
                yield return new Report();
                yield return new Report();
            }
        }

        public IEnumerable<Report> GetReportsByDay(DateTime date)
        {
            var reportsByDate = new List<Report> { new Report(), new Report() };
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
                    Grams = 100,
                    UserId = userId,
                },
                new UserDish
                {
                    Date = date,
                    Dish = dishes[1],
                    Grams = 100,
                    UserId = userId
                }
            };
            return dishesOfUser;
        }

        public List<UserDish> GetUserDishesWithViolations(List<Dish> dishes, DateTime date, int userId)
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
    }

}
