using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Models;

namespace DietAssistant.BLL.Validators
{
    public class FatRangeValidator : IRangeValidator
    {
        private readonly NutritionLimits _nutritionLimits;

        public FatRangeValidator(NutritionLimits nutritionProperties)
        {
            _nutritionLimits = nutritionProperties;
        }

        public void Validate(ReportDto report)
        {
            if (report.Fats < _nutritionLimits.MinFats || report.Fats > _nutritionLimits.MaxFats)
            {
                report.WarningByFats =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of fats." +
                    $" Min norm is {_nutritionLimits.MinFats}. Max norm is {_nutritionLimits.MaxFats} ";
            }
        }
    }
}
