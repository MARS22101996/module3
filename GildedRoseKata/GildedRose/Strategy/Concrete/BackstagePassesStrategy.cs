using GildedRose.Enums;
using GildedRose.Models;

namespace GildedRose.Strategy.Concrete
{
    public class BackstagePassesStrategy : AbstractStrategy
    {
        public override GoodsType Name => GoodsType.BackstagePasses;

        protected override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality++;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                    }
                }
            }
        }
    }
}