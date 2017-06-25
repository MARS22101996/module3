using System;
using System.Collections.Generic;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.Interfaces
{
    public interface IReportService
    {
        ReportDto GetReportForUser(DateTime date, UserDto userDto);

        void SaveReport(ReportDto report);

        IEnumerable<ReportDto> GetDailyStatistic(DateTime date);

        ReportByType GetAverageDailyReportByBodyType(DateTime date, BodyType bodyType);
    }
}
