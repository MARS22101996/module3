using GildedRose.Enums;

namespace GildedRose.Models
{
    public class Item
    {
        public GoodsType Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
