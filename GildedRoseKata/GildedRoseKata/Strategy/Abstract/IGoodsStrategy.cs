using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Strategy.Abstract
{
    public interface IGoodsStrategy
    {
        GoodsType Name { get; }

        void UpdateGoods(Item item);
    }
}
