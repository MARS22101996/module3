using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.Interfaces
{
    public interface IRangeValidator
    {
        void Validate(ReportDto report);
    }
}