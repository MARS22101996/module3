using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Interfaces;

namespace DietAssistant.Core.Infrastructure.Validators
{
    public class ProteinRangeValidator : IRangeValidator
    {
        private readonly NutritionLimits _nutritionLimits;

        public ProteinRangeValidator(NutritionLimits nutritionProperties)
        {
            _nutritionLimits = nutritionProperties;
        }

        public void Validate(ReportDto report)
        {
            if (report.Proteins < _nutritionLimits.MinProtein || report.Proteins > _nutritionLimits.MaxProtein)
            {
                report.WarningByProteins =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of proteins." +
                    $" Min norm is {_nutritionLimits.MinProtein}. Max norm is {_nutritionLimits.MaxProtein} ";
            }
        }
    }
}