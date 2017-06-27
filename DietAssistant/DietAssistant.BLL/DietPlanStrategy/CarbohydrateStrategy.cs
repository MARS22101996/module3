using System.Collections.Generic;
using System.Linq;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class CarbohydrateStrategy : AbstractStrategy, IDietStrategy
    {
        public DietStrategy Name => DietStrategy.CarbohydrateBased;

        public List<Dish> CheckSet(double allowedValue, List<Dish> items, List<Dish> bestItems,
            ref double bestProteinValue, ref double bestFatValue)
        {
            var sum = CalculateAllElements(items);

            if (!bestItems.Any())
            {
                if (sum.CarboSum <= allowedValue && sum.CarboSum > NutritionLimits.MinCarbohydrates &&
                    sum.ProteinsSum > NutritionLimits.MinProtein &&
                    sum.ProteinsSum < NutritionLimits.MaxProtein &&
                    sum.FatsSum > NutritionLimits.MinFats && sum.FatsSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestProteinValue = sum.ProteinsSum;
                    bestFatValue = sum.FatsSum;
                }
            }
            else
            {
                if (sum.CarboSum <= allowedValue && sum.CarboSum > NutritionLimits.MinCarbohydrates
                    && sum.ProteinsSum < bestProteinValue && sum.ProteinsSum > NutritionLimits.MinProtein &&
                    sum.ProteinsSum < NutritionLimits.MaxProtein &&
                    sum.FatsSum < bestFatValue && sum.FatsSum > NutritionLimits.MinFats && sum.FatsSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestProteinValue = sum.ProteinsSum;
                    bestFatValue = sum.FatsSum;
                }
            }
            return bestItems;
        }
    }
}