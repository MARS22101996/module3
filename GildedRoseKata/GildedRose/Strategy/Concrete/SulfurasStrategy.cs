using GildedRose.Enums;
using GildedRose.Models;

namespace GildedRose.Strategy.Concrete
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