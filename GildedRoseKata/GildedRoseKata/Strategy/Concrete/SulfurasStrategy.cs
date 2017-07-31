using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Strategy.Concrete
{
    public class SulfurasStrategy : AbstractStrategy
    {
        public override GoodsType Name => GoodsType.Sulfuras;

        protected override void UpdateQuality(Item item)
        {
        }

        protected override void UpdateSellIn(Item item)
        {
        }
    }
}