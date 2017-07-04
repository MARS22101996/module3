using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Interfaces;

namespace DietAssistant.Core.Infrastructure.Validators
{
    public class CarbohydratesRangeValidator : IRangeValidator
    {
        private readonly NutritionLimits _nutritionLimits;

        public CarbohydratesRangeValidator(NutritionLimits nutritionProperties)
        {
            _nutritionLimits = nutritionProperties;
        }

        public void Validate(ReportDto report)
        {
            if (report.Carbohydrates < _nutritionLimits.MinCarbohydrates ||
                report.Carbohydrates > _nutritionLimits.MaxCarbohydrates)
            {
                report.WarningByCarbohydrates =
                    $"User {report.User.FirstName} {report.User.LastName} violated the daily rate daily rate of carbohydrates." +
                    $" Min norm is {_nutritionLimits.MinCarbohydrates}. Max norm is {_nutritionLimits.MaxCarbohydrates} ";
            }
        }
    }
}