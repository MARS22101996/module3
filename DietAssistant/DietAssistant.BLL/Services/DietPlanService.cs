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

        public void MakeAllSetsOfDishes(List<Dish> items, DietStrategy strategy, double allowedValue)
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

                MakeAllSetsOfDishes(newSet, strategy, allowedValue);
            }

        }

        public DietPlan GetBestSetOfDishes()
        {
            var dietPlan = new DietPlan { Dishes = _bestItems };
            if (!_bestItems.Any())
            {
                dietPlan.Warning = "it is impossible to make a diet with such input values. It violates the daily rate.";
            }
            return dietPlan;
        }
    }
}