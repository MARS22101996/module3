using System;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.Models
{
    public class ReportByType
    {
        public DateTime Date { get; set; }
     
        public double AverageCarbohydrates { get; set; }

        public double AverageFats { get; set; }

        public double AverageProteins { get; set; }

        public BodyType Type { get; set; }
    }
}
