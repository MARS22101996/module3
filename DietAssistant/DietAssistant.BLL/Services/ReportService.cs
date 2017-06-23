using DietAssistant.Interfaces;
using System;
using System.Linq;
using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Interfaces;
using DietAssistant.Entities;

namespace DietAssistant.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ReportDto GetReportForUser(DateTime date, int userId)
        {
            var dishesOfUser= _unitOfWork.UserDishes.Find(x => x.Date == date && x.UserId == userId).ToList();

            var totalCarbohydrates = dishesOfUser.Sum(x => x.Dish.CarbohydratesPer100Grams * (x.Grams / 100.0));

            var totalFats = dishesOfUser.Sum(x => x.Dish.FatsPer100Grams * (x.Grams / 100.0));

            var totalProteins = dishesOfUser.Sum(x => x.Dish.ProteinsPer100Grams * (x.Grams / 100.0));

            var user = _unitOfWork.Users.Get(userId);

            var userDto = Mapper.Map<UserDto>(user);

            var report = new ReportDto() { Date = date, Carbohydrates = totalCarbohydrates, Fats = totalFats, Proteins = totalProteins, UserId = userId, User = userDto};

            return report;
        }

        public void SaveReport(ReportDto reportDto)
        {
            var report = Mapper.Map<Report>(reportDto);

            _unitOfWork.Reports.Create(report);

            _unitOfWork.Save();
        }

    }
}
