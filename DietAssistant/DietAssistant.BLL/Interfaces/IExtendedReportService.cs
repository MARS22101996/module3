using System;
using System.Collections.Generic;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.Interfaces
{
    public interface IExtendedReportService
    {
        IEnumerable<ReportDto> GetDailyStatistic(DateTime date);

        ReportByType GetAverageDailyReportByBodyType(DateTime date, BodyType bodyType);
    }
}
