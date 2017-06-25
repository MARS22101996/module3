using System.Collections.Generic;

namespace DietAssistant.BLL.Dto
{
    public class DishDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double CarbohydratesPer100Grams { get; set; }

        public double FatsPer100Grams { get; set; }

        public double ProteinsPer100Grams { get; set; }

        public IEnumerable<UserDishDto> UserDishes { get; set; }
    }
}
