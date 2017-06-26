using System.Collections.Generic;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public interface IDietStrategy 
    {
        DietStrategy Name { get; }

        List<Dish> CheckSet(double allowedValue, List<Dish> items, List<Dish> bestItems, ref double bestCarboValue,
            ref double bestFatValue);
    }
}
