using System;
using System.Collections.Generic;

namespace Algorithm.DietPlanStrategy
{
    public interface IDietStrategy 
    {
        DietStrategy Name { get; }

        List<Dish> CheckSet(StrategyModel model, List<Dish> items, List<Dish> bestItems, ref double bestCarboValue,
            ref double bestFatValue);
    }
}
