using System.Collections.Generic;
using DietAssistant.Core.Enums;
using DietAssistant.BLL.Models;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.Interfaces
{
    public interface IDietPlanService
    {
        IEnumerable<DishDto> MakeAllSetsOfDishes(List<DishDto> items, DietStrategy strategy, double allowedValue);

        DietPlan GetDietPlan(List<DishDto> items);
    }
}