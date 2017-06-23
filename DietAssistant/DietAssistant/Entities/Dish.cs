using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DietAssistant.Entities
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double CarbohydratesPer100Grams { get; set; }

        public double FatsPer100Grams { get; set; }

        public double ProteinsPer100Grams { get; set; }

        public virtual ICollection<UserDish> UserDishes { get; set; }

    }
}
