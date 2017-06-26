using System.Collections.Generic;
using DietAssistant.Entities;

namespace DietAssistant.BLL.Models
{
    public class DietPlan
    {
        public List<Dish> Dishes { get; set; }

        public string Warning { get; set; }
    }
}