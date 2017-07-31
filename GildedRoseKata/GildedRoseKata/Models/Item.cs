using GildedRoseKata.Enums;

namespace GildedRoseKata.Models
{
    public class Item
    {
        public GoodsType Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
