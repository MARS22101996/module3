using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietAssistant.Entities
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public double Carbohydrates { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public string WarningByCarbohydrates { get; set; }

        public string WarningByFats { get; set; }

        public string WarningByProteins { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
