using System;

namespace DietAssistant.BLL.Dto
{
    public class UserDishDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int DishId { get; set; }

        public int UserId { get; set; }

        public int Grams { get; set; }

        public  DishDto Dish { get; set; }

        public  UserDto User { get; set; }
    }
}
