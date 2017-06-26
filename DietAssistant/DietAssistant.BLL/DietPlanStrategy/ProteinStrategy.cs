using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;
using Algorithm.DietPlanStrategy;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class ProteinStrategy : AbstractStrategy, IDietStrategy
    {
        public DietStrategy Name => DietStrategy.ProteinBased;

        public List<Dish> CheckSet(double allowedValue,  List<Dish> items, List<Dish> bestItems,
            ref double bestCarboValue, ref double bestFatValue)
        {
            var proteinSum = CalculateProteins(items);
            var fatSum = CalculateFats(items);
            var carboSum = CalculateCarbohydrates(items);
            if (!bestItems.Any())
            {
                if (proteinSum <= allowedValue && proteinSum > NutritionLimits.MinProtein &&
                    carboSum > NutritionLimits.MinCarbohydrates &&
                    carboSum < NutritionLimits.MaxCarbohydrates &&
                    fatSum > NutritionLimits.MinFats && fatSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestCarboValue = carboSum;
                    bestFatValue = fatSum;
                }
            }
            else
            {
                if (proteinSum <= allowedValue && proteinSum > NutritionLimits.MinProtein
                    && carboSum < bestCarboValue && carboSum > NutritionLimits.MinCarbohydrates &&
                    carboSum < NutritionLimits.MaxCarbohydrates &&
                    fatSum < bestFatValue && fatSum > NutritionLimits.MinFats && fatSum < NutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestCarboValue = carboSum;
                    bestFatValue = fatSum;
                }
            }
            return bestItems;
        }
    }
}