using GildedRose.Enums;
using GildedRose.Models;

namespace GildedRose.Strategy.Abstract
{
    public interface IGoodsStrategy
    {
        GoodsType Name { get; }

        void UpdateGoods(Item item);
    }
}
