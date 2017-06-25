using System;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.Interfaces
{
    public interface IReportService
    {
        ReportDto GetReportForUser(DateTime date, UserDto userDto);

        void SaveReport(ReportDto report);
    }
}
