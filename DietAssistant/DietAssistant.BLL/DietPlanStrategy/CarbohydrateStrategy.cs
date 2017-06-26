using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;
using Algorithm.DietPlanStrategy;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class CarbohydrateStrategy : AbstractStrategy, IDietStrategy
    {
        public DietStrategy Name => DietStrategy.CarbohydrateBased;
        public List<Dish> CheckSet(double allowedValue, List<Dish> items, List<Dish> bestItems,
            ref double bestProteinValue, ref double bestFatValue)
        {
            var proteinSum = CalculateProteins(items);
            var fatSum = CalculateFats(items);
            var carboSum = CalculateCarbohydrates(items);
            if (!bestItems.Any())
            {
                if (carboSum <=allowedValue && carboSum > NutritionLimits.MinCarbohydrates  && proteinSum > NutritionLimits.MinProtein &&
                    proteinSum < NutritionLimits.MaxProtein &&
                    fatSum > NutritionLimits.MinFats && fatSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestProteinValue = proteinSum;
                    bestFatValue = fatSum;
                }
            }
            else
            {
                if (carboSum <= allowedValue && carboSum > NutritionLimits.MinCarbohydrates
                    && proteinSum < bestProteinValue && proteinSum > NutritionLimits.MinProtein &&
                    proteinSum < NutritionLimits.MaxProtein &&
                    fatSum < bestFatValue && fatSum > NutritionLimits.MinFats && fatSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestProteinValue = proteinSum;
                    bestFatValue = fatSum;
                }
            }
            return bestItems;
        }
    }
}