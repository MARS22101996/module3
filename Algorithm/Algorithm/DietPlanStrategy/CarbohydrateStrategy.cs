using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.DietPlanStrategy
{
    public class CarbohydrateStrategy : IDietStrategy
    {
        private readonly NutritionLimits _nutritionLimits;
        public DietStrategy Name => DietStrategy.CarbohydrateBased;

        public CarbohydrateStrategy()
        {
            _nutritionLimits = new NutritionLimits();
        }

        public List<Dish> CheckSet(StrategyModel model,  List<Dish> items, List<Dish> bestItems,
            ref double bestProteinValue, ref double bestFatValue)
        {
            var proteinSum = model.Proteins(items);
            var fatSum = model.Fats(items);
            var carboSum = model.Carbohydrates(items);
            if (!bestItems.Any())
            {
                if (carboSum <= model.AllowedValue && carboSum > _nutritionLimits.MinCarbohydrates  && proteinSum > _nutritionLimits.MinProtein &&
                    proteinSum < _nutritionLimits.MaxProtein &&
                    fatSum > _nutritionLimits.MinFats && fatSum < _nutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestProteinValue = proteinSum;
                    bestFatValue = fatSum;
                }
            }
            else
            {
                if (carboSum <= model.AllowedValue && carboSum > _nutritionLimits.MinCarbohydrates
                    && proteinSum < bestProteinValue && proteinSum > _nutritionLimits.MinProtein &&
                    proteinSum < _nutritionLimits.MaxProtein &&
                    fatSum < bestFatValue && fatSum > _nutritionLimits.MinFats && fatSum < _nutritionLimits.MaxFats)
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