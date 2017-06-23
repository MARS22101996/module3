using System;

namespace DietAssistant.BLL.Dto
{
    public class ReportDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public double  Carbohydrates { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public UserDto User { get; set; }

    }
}