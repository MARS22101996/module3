using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;
using Algorithm.DietPlanStrategy;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class FatStrategy : AbstractStrategy, IDietStrategy
    {
        public DietStrategy Name => DietStrategy.FatBased;

        public List<Dish> CheckSet(double allowedValue, List<Dish> items, List<Dish> bestItems,
            ref double bestCarboValue, ref double bestProteinValue)
        {
            var proteinSum = CalculateProteins(items);
            var fatSum = CalculateFats(items);
            var carboSum =CalculateCarbohydrates(items);
            if (!bestItems.Any())
            {
                if (fatSum <= allowedValue && fatSum > NutritionLimits.MinFats &&
                    carboSum > NutritionLimits.MinCarbohydrates &&
                    carboSum < NutritionLimits.MaxCarbohydrates &&
                    proteinSum > NutritionLimits.MinProtein && proteinSum < NutritionLimits.MaxProtein)
                {
                    bestItems = items;
                    bestCarboValue = carboSum;
                    bestProteinValue = proteinSum;
                }
            }
            else
            {
                if (fatSum <=allowedValue && fatSum > NutritionLimits.MinFats &&
                    carboSum > NutritionLimits.MinCarbohydrates &&
                    carboSum < NutritionLimits.MaxCarbohydrates &&
                    proteinSum > NutritionLimits.MinProtein && proteinSum < NutritionLimits.MaxProtein
                    && carboSum < bestCarboValue && proteinSum < bestProteinValue)
                {
                    bestItems = items;
                    bestCarboValue = carboSum;
                    bestProteinValue = proteinSum;
                }
            }
            return bestItems;
        }
    }
}