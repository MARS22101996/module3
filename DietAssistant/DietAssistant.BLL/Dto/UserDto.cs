using System.Collections.Generic;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public BodyType Type { get; set; }

        public ICollection<UserDishDto> UserDishes { get; set; }

    }
}
