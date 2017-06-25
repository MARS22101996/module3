using System.Configuration;

namespace DietAssistant.BLL.Models
{
    public class NutritionLimits
    {
        public double MinCarbohydrates { get; }
        public double MaxCarbohydrates { get; }
        public double MinFats { get; }
        public double MaxFats { get; }
        public double MinProtein { get; }
        public double MaxProtein { get; }

        public NutritionLimits()
        {

            MaxCarbohydrates = double.Parse(ConfigurationManager.AppSettings["maxCarbohydrates"]);
            MinCarbohydrates = double.Parse(ConfigurationManager.AppSettings["minCarbohydrates"]);
            MinFats = double.Parse(ConfigurationManager.AppSettings["minFats"]);
            MaxFats = double.Parse(ConfigurationManager.AppSettings["maxFats"]);
            MinProtein = double.Parse(ConfigurationManager.AppSettings["minProtein"]);
            MaxProtein = double.Parse(ConfigurationManager.AppSettings["maxProtein"]);
        }
    }
}
