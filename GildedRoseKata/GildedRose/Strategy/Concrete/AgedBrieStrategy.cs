using GildedRose.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Strategy.Concrete
{
    public class AgedBrieStrategy : AbstractStrategy
    {
        public override GoodsType Name => GoodsType.AgedBrie;

        protected override void UpdateQuality(Item item)
        {
            if (item.Quality > 50) return;
            if (item.SellIn < 0)
                item.Quality += 2;
            else
                item.Quality += 1;
        }
    }
}