using System.Collections.Generic;
using System.Linq;
using GildedRose.Enums;
using GildedRoseKata.Infrastructure.Exceptions;
using GildedRoseKata.Strategy.Abstract;

namespace GildedRoseKata.Strategy
{
    public class GoodsProvider
    {
        private readonly IEnumerable<IGoodsStrategy> _goodsStrategies;

        public GoodsProvider(IEnumerable<IGoodsStrategy> goodsStrategies)
        {
            _goodsStrategies = goodsStrategies;
        }
        public IGoodsStrategy GetDietStrategy(GoodsType name)
        {
            var result = _goodsStrategies.FirstOrDefault(x => x.Name == name);
            if (result == null)
            {
                throw new EntityNotFoundException($"Goods strategy {name} was not found", "Strategy");
            }
            return result;
        }
    }
}
