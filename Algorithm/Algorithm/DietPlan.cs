using System.Collections.Generic;
using Algorithm.DietPlanStrategy;

namespace Algorithm
{
    public class DietPlan
    {
        private List<Dish> _bestItems;

        private double _bestFirstValue;

        private double _bestSecondValue;

        private readonly DietProvider _dietProvider;

        public DietPlan()
        {
            var list = new List<IDietStrategy>
            {
                new CarbohydrateStrategy(),
                new FatStrategy(),
                new ProteinStrategy()
            };
        
            _dietProvider = new DietProvider(list);
            _bestItems = new List<Dish>();
        }

        public void MakeAllSets(List<Dish> items, DietStrategy strategy, double allowedValue)
        {
            if (items.Count > 0)
            {
                _bestItems = _dietProvider.GetDietStrategy(strategy)
                    .CheckSet(allowedValue, items, _bestItems, ref _bestSecondValue, ref _bestFirstValue);
            }

            for (var i = 0; i < items.Count; i++)
            {
                var newSet = new List<Dish>(items);

                newSet.RemoveAt(i);

                MakeAllSets(newSet, strategy, allowedValue);
            }
        }

        public List<Dish> GetBestSet()
        {
            return _bestItems;
        }
    }
}
