using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Infrastructure.Exceptions;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;
using DietAssistant.Interfaces;
using DietAssistant.Entities;

namespace DietAssistant.BLL.Services
{
    public class ExtendedReportService : IExtendedReportService
    {
        private readonly IUnitOfWork _unitOfWork;
      
        public ExtendedReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ReportByType GetAverageDailyReportByBodyType(DateTime date, BodyType bodyType)
        {
            var dailyReports = _unitOfWork.Reports.Find(x => x.Date == date && x.User.Type == bodyType).ToList();

            if (!dailyReports.Any())
            {
                throw new EntityNotFoundException(
                    $"Users with such body type doesn't have reports for this date. Type: {bodyType}. Date: {date}",
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
    }
}