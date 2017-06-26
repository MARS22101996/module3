﻿using System.Collections.Generic;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;
using DietAssistant.BLL.Models;

namespace DietAssistant.BLL.Interfaces
{
    public interface IDietPlanService
    {
        void MakeAllSetsOfDishes(List<Dish> items, DietStrategy strategy, double allowedValue);

        DietPlan GetBestSetOfDishes();
    }
}