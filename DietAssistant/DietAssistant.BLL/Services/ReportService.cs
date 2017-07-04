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

namespace DietAssistant.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NutritionLimits _nutritionLimits;
        private readonly IEnumerable<IRangeValidator> _rangeValidators;

        public ReportService(IUnitOfWork unitOfWork, IEnumerable<IRangeValidator> rangeValidators)
        {
            _unitOfWork = unitOfWork;
            _nutritionLimits = new NutritionLimits();
            _rangeValidators = rangeValidators;
        }

        public ReportDto GetReportForUser(DateTime date, UserDto userDto)
        {
            var dishesOfUser = GetDishesOfUserByDate(date, userDto.Id).ToList();

            if (!dishesOfUser.Any())
            {
                throw new EntityNotFoundException(
                    $"User with such id doesn't have dishes for this date. Id: {userDto.Id}. Date: {date}",
                    "UserDish");
            }

            var report = new ReportDto
            {
                Date = date,
                Carbohydrates = dishesOfUser.Sum(x => x.Dish.CarbohydratesPer100Grams * (x.Grams / 100.0)),
                Fats = dishesOfUser.Sum(x => x.Dish.FatsPer100Grams * (x.Grams / 100.0)),
                Proteins = dishesOfUser.Sum(x => x.Dish.ProteinsPer100Grams * (x.Grams / 100.0)),
                UserId = userDto.Id,
                User = userDto
            };

            GetWarnings(report, _rangeValidators);

            return report;
        }

        public void SaveReport(ReportDto reportDto)
        {
            var report = Mapper.Map<Report>(reportDto);

            _unitOfWork.Reports.Create(report);

            _unitOfWork.Save();
        }
      

        private IEnumerable<UserDish> GetDishesOfUserByDate(DateTime date, int userId)
        {
            var dishesOfUser = _unitOfWork.UserDishes.Find(x => x.Date == date && x.UserId == userId);

            return dishesOfUser;
        }

        private void GetWarnings(ReportDto report, IEnumerable<IRangeValidator> validators)
        {
            foreach(var validator in validators)
            {
                validator.Validate(report);
            }
        }
    }
}