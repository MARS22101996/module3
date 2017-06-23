using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.Interfaces
{
    public interface IReportService
    {
        ReportDto GetReportForUser(DateTime date, int userId);

        void SaveReport(ReportDto report);
    }
}
