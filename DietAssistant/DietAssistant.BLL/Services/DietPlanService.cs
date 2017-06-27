using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.DietPlanStrategy;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Models;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;

namespace DietAssistant.BLL.Services
{
    public class DietPlanService : IDietPlanService
    {
        private List<Dish> _bestItems;

        private double _bestFirstValue;

        private double _bestSecondValue;

        private readonly DietProvider _dietProvider;

        public DietPlanService(IEnumerable<IDietStrategy> diets)
        {
            _dietProvider = new DietProvider(diets);
            _bestItems = new List<Dish>();
        }

        public IEnumerable<Dish> MakeAllSetsOfDishes(List<Dish> items, DietStrategy strategy, double allowedValue)
        {

            if (items.Count > 0)
            {
                _bestItems = _dietProvider.GetDietStrategy(strategy)
                    .CheckSet(allowedValue, items, _bestItems, ref _bestSecondValue, ref _bestFirstValue);
            }

            for (var item = 0; item < items.Count; item ++)
            {
                var newSet = new List<Dish>(items);

                newSet.RemoveAt(item);

                MakeAllSetsOfDishes(newSet, strategy, allowedValue);
            }

            return _bestItems;
        }

        public DietPlan GetDietPlan(List<Dish> bestItems)
        {
            var dietPlan = new DietPlan { Dishes = bestItems };
            if (!bestItems.Any())
            {
                dietPlan.Warning =
                    "It is impossible to make a diet with such input values. It violates the daily rate.";
            }
            return dietPlan;
        }
    }
}