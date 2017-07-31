using System.Collections.Generic;
using GildedRose.Enums;
using GildedRose.Models;
using GildedRose.Strategy;
using GildedRose.Strategy.Abstract;
using GildedRose.Strategy.Concrete;
using NUnit.Framework;

namespace GildedRose.Tests.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private GoodsProvider _strategyProvider;

        [SetUp]
        public void Setup()
        {
            var goodsStrategies = new List<IGoodsStrategy>
            {
                new AgedBrieStrategy(),
                new BackstagePassesStrategy(),
                new SulfurasStrategy(),
                new ConjuredStrategy(),
                new AbstractStrategy()
            };

            _strategyProvider = new GoodsProvider(goodsStrategies);
        }

        [Test]
        public void UpdateGoods_IncreasesTheQuality_SellInIsMoreThan0_WhenItemIsAgedBrie()
        {
            const int sellIn = 1;

            const int quality = 7;

            var product = new Item { Name = GoodsType.AgedBrie, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality + 1, product.Quality);
        }

        [Test]
        public void UpdateGoods_DoesNotIncreaseTheQuality_WhenMoreThan50_WhenItemIsAgedBrie()
        {
            const int sellIn = 1;

            const int quality = 50;

            var product = new Item { Name = GoodsType.AgedBrie, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        public void UpdateGoods_DoesNotIncreaseTheQuality_WhenQualityIsMoreThan50_WhenItemIsBackstagePasses()
        {
            const int sellIn = 12;

            const int quality = 50;

            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        public void UpdateGoods_DoesNotChangeQuality_WhenItemIsSulfuras()
        {
            const int sellIn = 12;

            const int quality = 80;

            var product = new Item { Name = GoodsType.Sulfuras, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality, product.Quality);
        }

        [Test]
        public void UpdateGoods_DoesNotChangeSellIn_WhenItemIsSulfuras()
        {
            const int sellIn = 12;

            const int quality = 80;

            var product = new Item { Name = GoodsType.Sulfuras, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(sellIn, product.SellIn);
        }

        [Test]
        public void UpdateGoods_IncreasesTheQualityBy2_WhenSellInIsLessThan11_WhenItemIsBackstagePasses()
        {
            const int sellIn = 10;

            const int quality = 5;

            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality + 2, product.Quality);
        }

        [Test]
        public void UpdateGoods_IncreasesTheQualityBy3_WhenSellInIsLessThan5_WhenItemIsBackstagePasses()
        {
            const int sellIn = 3;

            const int quality = 10;

            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality + 3, product.Quality);
        }

        [Test]
        public void UpdateGoods_SetsTheQualityTo0_WhenSellInEqualsOrLessThan0_WhenItemIsBackstagePasses()
        {
            const int sellIn = 0;

            const int quality = 6;

            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(0, product.Quality);
        }

        [Test]
        public void UpdateGoods_DecreasesTheQualityBy2_WhenItemIsConjured()
        {
            const int sellIn = 3;

            const int quality = 8;

            var product = new Item { Name = GoodsType.Conjured, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality - 2, product.Quality);
        }

        [Test]
        public void UpdateGoods_DecreasesTheQualityBy4_WhenSellInIsLessThan0_ForConjured()
        {
            const int sellIn = -1;

            const int quality = 8;

            var product = new Item { Name = GoodsType.Conjured, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality - 4, product.Quality);
        }

        [Test]
        public void UpdateGoods_DecreasesSell_WhenItemsAreDefault()
        {
            const int sellIn = 7;

            const int quality = 9;

            var product = new Item { Name = GoodsType.Default, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(sellIn - 1, product.SellIn);
        }

        [Test]
        public void UpdateGoods_DecreasesQualityByOne_WhenItemsAreDefault()
        {
            const int sellIn = 7;

            const int quality = 9;

            var product = new Item { Name = GoodsType.Default, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality - 1, product.Quality);
        }

        [Test]
        public void UpdateGoods_DecreasesQualityBy2_WhenSellInValueLessThenNull_ForDefaultItems()
        {
            const int sellIn = -2;

            const int quality = 9;

            var product = new Item { Name = GoodsType.Default, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality - 2, product.Quality);
        }

        [Test]
        public void UpdateGoods_SetQualityTo0_WhenQualityIsLessThan0_WhenItemIsDefault()
        {
            const int sellIn = -2;

            const int quality = -5;

            var product = new Item { Name = GoodsType.Default, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(0, product.Quality);
        }

        [Test]
        public void UpdateGoods_IncreasesTheQuality_SellInIsLessThenNull_WhenItemIsAgedBrie()
        {
            const int sellIn = -1;

            const int quality = 7;

            var product = new Item { Name = GoodsType.AgedBrie, SellIn = sellIn, Quality = quality };

            UpdateGoods(product);

            Assert.AreEqual(quality + 2, product.Quality);
        }

        private void UpdateGoods(Item product)
        {
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetGoodsStrategy(item.Name).UpdateGoods(item);
            }
        }
    }
}