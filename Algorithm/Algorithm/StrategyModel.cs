using System;
using System.Collections.Generic;

namespace Algorithm
{
    public class StrategyModel
    {
        public StrategyModel(Func<List<Dish>, double> proteins, Func<List<Dish>, double> carbohydrates,
            Func<List<Dish>, double> fats, double allowedValue)
        {
            Proteins = proteins;
            Carbohydrates = carbohydrates;
            Fats = fats;
            AllowedValue = allowedValue;
        }

        public double AllowedValue { get; }
        public Func<List<Dish>, double> Proteins { get; }
        public Func<List<Dish>, double> Carbohydrates { get; }
        public Func<List<Dish>, double> Fats { get; }
    }
}
