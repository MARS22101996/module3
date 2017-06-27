using System.Collections.Generic;
using DietAssistant.Core.Enums;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public interface IDietStrategy
    {
        DietStrategy Name { get; }

        List<DishDto> CheckSet(double allowedValue, List<DishDto> items, List<DishDto> bestItems, ref double bestCarboValue,
            ref double bestFatValue);
    }
}
