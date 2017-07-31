using GildedRose.Enums;
using GildedRose.Models;

namespace GildedRose.Strategy.Concrete
{
    public class ConjuredStrategy : AbstractStrategy
    {
        public override GoodsType Name => GoodsType.Conjured;

        protected override void UpdateQuality(Item item)
        {
            if (item.Quality <= 0) return;
            if (item.SellIn < 0)
                item.Quality -= 4;
            else
                item.Quality -= 2;
        }
    }
}