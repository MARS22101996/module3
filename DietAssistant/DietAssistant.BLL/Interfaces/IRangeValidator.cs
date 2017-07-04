using DietAssistant.BLL.Dto;

namespace DietAssistant.Core.Interfaces
{
    public interface IRangeValidator
    {
        void Validate(ReportDto report);
    }
}