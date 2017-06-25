using DietAssistant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Infrastructure.Exceptions;
using DietAssistant.BLL.Interfaces;
using DietAssistant.Entities;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NutritionLimits _nutritionLimits;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _nutritionLimits = new NutritionLimits();           
        }

        public ReportDto GetReportForUser(DateTime date, UserDto userDto)
        {
            var dishesOfUser = GetDishesOfUserByDate(date, userDto.Id).ToList();

            if (!dishesOfUser.Any())
            {
                throw new EntityNotFoundException(
                    $"User with such id doesn't not have dishes for this date. Id: {userDto.Id}. Date: {date}",
                    "UserDish");
            }

            var report = new ReportDto
            {
                Date = date,
                Carbohydrates = CalculatesTotalCarbohydrates(dishesOfUser),
                Fats = CalculatesTotalFats(dishesOfUser),
                Proteins = CalculatesTotalProteins(dishesOfUser),
                UserId = userDto.Id,
                User = userDto
            };

            CheckByCarbohydrates(report);

            CheckByFats(report);

            CheckByProtein(report);

            return report;
        }

        public void SaveReport(ReportDto reportDto)
        {
            var report = Mapper.Map<Report>(reportDto);

            _unitOfWork.Reports.Create(report);

            _unitOfWork.Save();
        }

        public ReportByType GetAverageDailyReportByBodyType(DateTime date, BodyType bodyType)
        {
            var dailyReports = _unitOfWork.Reports.Find(x => x.Date == date && x.User.Type == bodyType).ToList();

            if (!dailyReports.Any())
            {
                throw new EntityNotFoundException(
                    $"Users with such body type doesn't not have reports for this date. Type: {bodyType}. Date: {date}",
                    "Report");
            }

            var reportByType = new ReportByType
            {
                Date = date,
                AverageCarbohydrates = CalculatesAverageCarbohydrates(dailyReports),
                AverageFats = CalculatesAverageFats(dailyReports),
                AverageProteins = CalculatesAverageProteins(dailyReports),
                Type = bodyType
            };

            return reportByType;
        }

        public IEnumerable<ReportDto> GetDailyStatistic(DateTime date)
        {
            var dailyReports = _unitOfWork.Reports.Find(x => x.Date == date).ToList();

            var dailyReportsDto = Mapper.Map<IEnumerable<ReportDto>>(dailyReports);

            return dailyReportsDto;
        }

        private IEnumerable<UserDish> GetDishesOfUserByDate(DateTime date, int userId)
        {
            var dishesOfUser = _unitOfWork.UserDishes.Find(x => x.Date == date && x.UserId == userId);

            return dishesOfUser;
        }

        private double CalculatesTotalCarbohydrates(IEnumerable<UserDish> dishesOfUser)
        {
            var totalCarbohydrates = dishesOfUser.Sum(x => x.Dish.CarbohydratesPer100Grams * (x.Grams / 100.0));
            return totalCarbohydrates;
        }

        private double CalculatesTotalFats(IEnumerable<UserDish> dishesOfUser)
        {
            var totalFats = dishesOfUser.Sum(x => x.Dish.FatsPer100Grams * (x.Grams / 100.0));
            return totalFats;
        }

        private double CalculatesTotalProteins(IEnumerable<UserDish> dishesOfUser)
        {
            var totalProteins = dishesOfUser.Sum(x => x.Dish.ProteinsPer100Grams * (x.Grams / 100.0));
            return totalProteins;
        }


        private double CalculatesAverageCarbohydrates(IEnumerable<Report> reports)
        {
            var averageCarbohydrates = reports.Average(x => x.Carbohydrates);
            return averageCarbohydrates;
        }

        private double CalculatesAverageFats(IEnumerable<Report> reports)
        {
            var averageFats = reports.Average(x => x.Fats);
            return averageFats;
        }

        private double CalculatesAverageProteins(IEnumerable<Report> reports)
        {
            var averageProteins = reports.Average(x => x.Proteins);
            return averageProteins;
        }

        private void CheckByCarbohydrates(ReportDto report)
        {
            if (report.Carbohydrates < _nutritionLimits.MinCarbohydrates ||
                report.Carbohydrates > _nutritionLimits.MaxCarbohydrates)
            {
                report.WarningByCarbohydrates =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of carbohydrates." +
                    $" Min norm is {_nutritionLimits.MinCarbohydrates}. Max norm is {_nutritionLimits.MaxCarbohydrates} ";
            }
        }

        private void CheckByFats(ReportDto report)
        {
            if (report.Fats < _nutritionLimits.MinFats || report.Fats > _nutritionLimits.MaxFats)
            {
                report.WarningByFats =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of fats." +
                    $" Min norm is {_nutritionLimits.MinFats}. Max norm is {_nutritionLimits.MaxFats} ";
            }
        }

        private void CheckByProtein(ReportDto report)
        {
            if (report.Proteins < _nutritionLimits.MinProtein || report.Proteins > _nutritionLimits.MaxProtein)
            {
                report.WarningByProteins =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of proteins." +
                    $" Min norm is {_nutritionLimits.MinProtein}. Max norm is {_nutritionLimits.MaxProtein} ";
            }
        }
    }
}
