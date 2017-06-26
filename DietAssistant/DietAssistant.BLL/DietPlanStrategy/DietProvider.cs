using System;
using System.Collections.Generic;
using System.Linq;
using DietAssistant.Core.Enums;

namespace DietAssistant.BLL.DietPlanStrategy
{
    public class DietProvider
    {
        private readonly IEnumerable<IDietStrategy> _dietStrategies;

        public DietProvider(IEnumerable<IDietStrategy> dietStrategies)
        {
            _dietStrategies = dietStrategies;
        }    
        public IDietStrategy GetDietStrategy(DietStrategy payment)
        { 
            var result = _dietStrategies.FirstOrDefault(x => x.Name == payment);
            if(result==null)
            {
                throw new Exception();
            }
            return result;
        }
    }
}