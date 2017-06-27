using System.Collections.Generic;
using System.Linq;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class ProteinStrategy : AbstractStrategy, IDietStrategy
    {
        public DietStrategy Name => DietStrategy.ProteinBased;

        public List<Dish> CheckSet(double allowedValue,  List<Dish> items, List<Dish> bestItems,
            ref double bestCarboValue, ref double bestFatValue)
        {
            var sum = CalculateAllElements(items);

            if (!bestItems.Any())
            {
                if (sum.ProteinsSum <= allowedValue && sum.ProteinsSum > NutritionLimits.MinProtein &&
                    sum.CarboSum > NutritionLimits.MinCarbohydrates &&
                    sum.CarboSum < NutritionLimits.MaxCarbohydrates &&
                    sum.FatsSum > NutritionLimits.MinFats && sum.FatsSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestCarboValue = sum.CarboSum;
                    bestFatValue = sum.FatsSum;
                }
            }
            else
            {
                if (sum.ProteinsSum <= allowedValue && sum.ProteinsSum > NutritionLimits.MinProtein
                    && sum.CarboSum < bestCarboValue && sum.CarboSum > NutritionLimits.MinCarbohydrates &&
                    sum.CarboSum < NutritionLimits.MaxCarbohydrates &&
                    sum.FatsSum < bestFatValue && sum.FatsSum > NutritionLimits.MinFats && sum.FatsSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestCarboValue = sum.CarboSum;
                    bestFatValue = sum.FatsSum;
                }
            }
            return bestItems;
        }
    }
}