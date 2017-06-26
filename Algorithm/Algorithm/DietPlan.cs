using System.Collections.Generic;
using System.Linq;
using Algorithm.DietPlanStrategy;

namespace Algorithm
{
    public class DietPlan
    {
        private List<Dish> _bestItems;

        private double _bestFirstValue;

        private double _bestSecondValue;

        private readonly StrategyModel _model;

        private readonly DietProvider _dietProvider;

        public DietPlan(double allowedValue)
        {
            var list = new List<IDietStrategy>
            {
                new CarbohydrateStrategy(),
                new FatStrategy(),
                new ProteinStrategy()
            };
            _model = new StrategyModel(CalculateProteins, CalculateCarbohydrates, CalculateFats, allowedValue);
            _dietProvider = new DietProvider(list);
            _bestItems = new List<Dish>();
        }

        public void MakeAllSets(List<Dish> items, DietStrategy strategy)
        {
            if (items.Count > 0)
            {
                _bestItems = _dietProvider.GetDietStrategy(strategy)
                    .CheckSet(_model, items, _bestItems, ref _bestSecondValue, ref _bestFirstValue);
            }

            for (var i = 0; i < items.Count; i++)
            {
                var newSet = new List<Dish>(items);

                newSet.RemoveAt(i);

                MakeAllSets(newSet, strategy);
            }

        }

        private double CalculateProteins(IEnumerable<Dish> items)
        {
            return items.Sum(i => i.ProteinsPer100Grams);
        }

        private double CalculateCarbohydrates(IEnumerable<Dish> items)
        {
            return items.Sum(i => i.CarbohydratesPer100Grams);
        }
        private double CalculateFats(IEnumerable<Dish> items)
        {
            return items.Sum(i => i.FatsPer100Grams);
        }

        public List<Dish> GetBestSet()
        {
            return _bestItems;
        }
    }
}
