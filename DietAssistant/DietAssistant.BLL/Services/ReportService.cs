using DietAssistant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Interfaces;
using DietAssistant.Entities;
using System.Configuration;

namespace DietAssistant.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly double _minCarbohydrates;
        private readonly double _maxCarbohydrates;
        private readonly double _minFats;
        private readonly double _maxFats;
        private readonly double _minProtein;
        private readonly double _maxProtein;
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _maxCarbohydrates = float.Parse(ConfigurationManager.AppSettings["maxCarbohydrates"]);
            _minCarbohydrates = float.Parse(ConfigurationManager.AppSettings["minCarbohydrates"]);
            _minFats = float.Parse(ConfigurationManager.AppSettings["minFats"]);
            _maxFats = float.Parse(ConfigurationManager.AppSettings["maxFats"]);
            _minProtein = float.Parse(ConfigurationManager.AppSettings["minProtein"]);
            _maxProtein = float.Parse(ConfigurationManager.AppSettings["maxProtein"]);
        }

        public ReportDto GetReportForUser(DateTime date, int userId)
        {
            var dishesOfUser = _unitOfWork.UserDishes.Find(x => x.Date == date && x.UserId == userId).ToList();

            var user = _unitOfWork.Users.Get(userId);

            var userDto = Mapper.Map<UserDto>(user);

            var report = new ReportDto()
            {
                Date = date,
                Carbohydrates = CalculatesTotalCarbohydrates(dishesOfUser),
                Fats = CalculatesTotalFats(dishesOfUser),
                Proteins = CalculatesTotalProteins(dishesOfUser),
                UserId = userId,
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

        private void CheckByCarbohydrates(ReportDto report)
        {
            if (report.Carbohydrates < _minCarbohydrates || report.Carbohydrates > _maxCarbohydrates)
            {
                report.WarningByCarbohydrates =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of carbohydrates." +
                    $" Min norm is {_minCarbohydrates}. Max norm is {_maxCarbohydrates} ";
            }
        }

        private void CheckByFats(ReportDto report)
        {
            if (report.Fats < _minFats || report.Fats > _maxFats)
            {
                report.WarningByFats =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of fats." +
                    $" Min norm is {_minFats}. Max norm is {_maxFats} ";
            }
        }

        private void CheckByProtein(ReportDto report)
        {
            if (report.Proteins < _minProtein || report.Proteins > _maxProtein)
            {
                report.WarningByProteins =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of proteins." +
                    $" Min norm is {_minProtein}. Max norm is {_maxProtein} ";
            }
        }
    }
}
