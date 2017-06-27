using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.Models;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class AbstractStrategy
    {
        protected readonly NutritionLimits NutritionLimits;

        protected AbstractStrategy()
        {
            NutritionLimits = new NutritionLimits();
        }

        protected double CalculateProteins(List<DishDto> items)
        {
            return items.Sum(i => i.ProteinsPer100Grams);
        }

        protected double CalculateCarbohydrates(List<DishDto> items)
        {
            return items.Sum(i => i.CarbohydratesPer100Grams);
        }

        protected double CalculateFats(List<DishDto> items)
        {
            return items.Sum(i => i.FatsPer100Grams);
        }

        protected TotalElements CalculateAllElements(List<DishDto> items)
        {
            var total = new TotalElements
            {
                ProteinsSum = CalculateProteins(items),
                FatsSum = CalculateFats(items),
                CarboSum = CalculateCarbohydrates(items),
            };
            return total;
        }
    }
}
