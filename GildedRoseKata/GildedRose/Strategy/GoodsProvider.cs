using System.Collections.Generic;
using System.Linq;
using GildedRose.Enums;
using GildedRose.Infrastructure.Exceptions;
using GildedRose.Strategy.Abstract;

namespace GildedRose.Strategy
{
    public class GoodsProvider
    {
        private readonly IEnumerable<IGoodsStrategy> _goodsStrategies;

        public GoodsProvider(IEnumerable<IGoodsStrategy> goodsStrategies)
        {
            _goodsStrategies = goodsStrategies;
        }
        public IGoodsStrategy GetGoodsStrategy(GoodsType name)
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
