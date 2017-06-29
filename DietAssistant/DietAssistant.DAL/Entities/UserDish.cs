using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietAssistant.Entities
{
    public class UserDish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int DishId { get; set; }

        public int UserId { get; set; }

        public int Grams { get; set; }

        [Required]
        [ForeignKey(nameof(DishId))]
        public virtual Dish Dish { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
