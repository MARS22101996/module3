using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.DietPlanStrategy
{
    public class ProteinStrategy : IDietStrategy
    {
        private readonly NutritionLimits _nutritionLimits;

        public DietStrategy Name => DietStrategy.ProteinBased;

        public ProteinStrategy()
        {
            _nutritionLimits = new NutritionLimits();
        }

        public List<Dish> CheckSet(StrategyModel model,  List<Dish> items, List<Dish> bestItems,
            ref double bestCarboValue, ref double bestFatValue)
        {
            var proteinSum = model.Proteins(items);
            var fatSum = model.Fats(items);
            var carboSum = model.Carbohydrates(items);
            if (!bestItems.Any())
            {
                if (proteinSum <= model.AllowedValue && proteinSum > _nutritionLimits.MinProtein &&
                    carboSum > _nutritionLimits.MinCarbohydrates &&
                    carboSum < _nutritionLimits.MaxCarbohydrates &&
                    fatSum > _nutritionLimits.MinFats && fatSum < _nutritionLimits.MaxFats)
                {
                    bestItems = items;
                    bestCarboValue = carboSum;
                    bestFatValue = fatSum;
                }
            }
            else
            {
                if (proteinSum <= model.AllowedValue && proteinSum > _nutritionLimits.MinProtein
                    && carboSum < bestCarboValue && carboSum > _nutritionLimits.MinCarbohydrates &&
                    carboSum < _nutritionLimits.MaxCarbohydrates &&
                    fatSum < bestFatValue && fatSum > _nutritionLimits.MinFats && fatSum < _nutritionLimits.MaxFats)
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