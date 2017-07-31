using GildedRose.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Strategy.Abstract;

namespace GildedRoseKata.Strategy.Concrete
{
    public class AbstractStrategy : IGoodsStrategy
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
   
        public virtual GoodsType Name => GoodsType.Default;

        public void UpdateGoods(Item item)
        {
            UpdateQuality(item);
            UpdateSellIn(item);
            if (item.Name != GoodsType.Sulfuras)
            {
                CheckQuality(item);
            }
        }

        protected virtual void UpdateQuality(Item item)
        {
            item.Quality -= item.SellIn < 0 ? 2 : 1;

            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
        }

        protected virtual void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        private void CheckQuality(Item item)
        {
            if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
            }

            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
        }
    }
}