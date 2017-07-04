using System.Collections.Generic;
using System.Linq;
using DietAssistant.Core.Enums;
using DietAssistant.BLL.Infrastructure.Exceptions;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class DietProvider
    {
        private readonly IEnumerable<IDietStrategy> _dietStrategies;

        public DietProvider(IEnumerable<IDietStrategy> dietStrategies)
        {
            _dietStrategies = dietStrategies;
        }    
        public IDietStrategy GetDietStrategy(DietStrategy diet)
        { 
            var result = _dietStrategies.FirstOrDefault(x => x.Name == diet);
            if(result == null)
            {
                throw new EntityNotFoundException($"Diet strategy {diet.ToString()} was not found", "Strategy");
            }
            return result;
        }
    }
}