using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.DietPlanStrategy
{
    public class FatStrategy : IDietStrategy
    {
        private readonly NutritionLimits _nutritionLimits;

        public DietStrategy Name => DietStrategy.FatBased;

        public FatStrategy()
        {
            _nutritionLimits = new NutritionLimits();
        }

        public List<Dish> CheckSet(StrategyModel model, List<Dish> items, List<Dish> bestItems,
            ref double bestCarboValue, ref double bestProteinValue)
        {
            var proteinSum = model.Proteins(items);
            var fatSum = model.Fats(items);
            var carboSum = model.Carbohydrates(items);
            if (!bestItems.Any())
            {
                if (fatSum <= model.AllowedValue && fatSum > _nutritionLimits.MinFats &&
                    carboSum > _nutritionLimits.MinCarbohydrates &&
                    carboSum < _nutritionLimits.MaxCarbohydrates &&
                    proteinSum > _nutritionLimits.MinProtein && proteinSum < _nutritionLimits.MaxProtein)
                {
                    bestItems = items;
                    bestCarboValue = carboSum;
                    bestProteinValue = proteinSum;
                }
            }
            else
            {
                if (fatSum <= model.AllowedValue && fatSum > _nutritionLimits.MinFats &&
                    carboSum > _nutritionLimits.MinCarbohydrates &&
                    carboSum < _nutritionLimits.MaxCarbohydrates &&
                    proteinSum > _nutritionLimits.MinProtein && proteinSum < _nutritionLimits.MaxProtein
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