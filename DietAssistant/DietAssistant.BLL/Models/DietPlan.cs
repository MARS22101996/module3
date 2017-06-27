using System.Collections.Generic;
using DietAssistant.BLL.Dto;

namespace DietAssistant.BLL.Models
{
    public class DietPlan
    {
        public List<DishDto> Dishes { get; set; }

        public string Warning { get; set; }
    }
}