using DietAssistant.BLL.Models;
using DietAssistant.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.DietPlanStrategy
{
    public class AbstractStrategy
    {
        protected readonly NutritionLimits NutritionLimits;

        protected AbstractStrategy()
        {
            NutritionLimits = new NutritionLimits();
        }

        protected double CalculateProteins(IEnumerable<Dish> items)
        {
            return items.Sum(i => i.ProteinsPer100Grams);
        }

        protected double CalculateCarbohydrates(IEnumerable<Dish> items)
        {
            return items.Sum(i => i.CarbohydratesPer100Grams);
        }

        protected double CalculateFats(IEnumerable<Dish> items)
        {
            return items.Sum(i => i.FatsPer100Grams);
        }
    }
}
