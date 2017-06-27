using System.Collections.Generic;
using System.Linq;
using DietAssistant.Core.Enums;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class FatStrategy : AbstractStrategy, IDietStrategy
    {
        public DietStrategy Name => DietStrategy.FatBased;

        public List<DishDto> CheckSet(double allowedValue, List<DishDto> items, List<DishDto> bestItems,
            ref double bestCarboValue, ref double bestProteinValue)
        {
            var sum = CalculateAllElements(items);
            if (!bestItems.Any())
            {
                if (sum.FatsSum <= allowedValue && sum.FatsSum > NutritionLimits.MinFats &&
                    sum.CarboSum > NutritionLimits.MinCarbohydrates &&
                    sum.CarboSum < NutritionLimits.MaxCarbohydrates &&
                    sum.ProteinsSum > NutritionLimits.MinProtein && sum.ProteinsSum < NutritionLimits.MaxProtein)
                {
                    bestItems = items;
                    bestCarboValue = sum.CarboSum;
                    bestProteinValue = sum.ProteinsSum;
                }
            }
            else
            {
                if (sum.FatsSum <= allowedValue && sum.FatsSum > NutritionLimits.MinFats &&
                    sum.CarboSum > NutritionLimits.MinCarbohydrates &&
                    sum.CarboSum < NutritionLimits.MaxCarbohydrates &&
                    sum.ProteinsSum > NutritionLimits.MinProtein && sum.ProteinsSum < NutritionLimits.MaxProtein
                    && sum.CarboSum < bestCarboValue && sum.ProteinsSum < bestProteinValue)
                {
                    bestItems = items;
                    bestCarboValue = sum.CarboSum;
                    bestProteinValue = sum.ProteinsSum;
                }
            }
            return bestItems;
        }
    }
}