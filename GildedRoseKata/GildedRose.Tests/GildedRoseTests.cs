using System.Collections.Generic;
using GildedRose.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Strategy;
using GildedRoseKata.Strategy.Abstract;
using GildedRoseKata.Strategy.Concrete;
using NUnit.Framework;

namespace GildedRose.Tests
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
        [TestCase(3, 5)]
        [TestCase(1, 50)]
        public void UpdateQuality_DecreasesSellInAndQualityBy1_ForGeneralItems(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.Default, SellIn = sellIn, Quality = quality };
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(sellIn - 1, product.SellIn);
            Assert.AreEqual(quality - 1, product.Quality);
        }

        [Test]
        [TestCase(-2, 5)]
        [TestCase(-1, 50)]
        [TestCase(0, 50)]
        public void UpdateQuality_DecreasesQualityBy2_WhenSellInValueLessThen0_ForGeneralItems(int sellIn, int quality)
        {
            var product = new Item {Name = GoodsType.Default, SellIn = sellIn, Quality = quality};
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(quality - 2, product.Quality);
        }

        [Test]
        [TestCase(5, 0)]
        [TestCase(-2, 1)]
        public void UpdateQuality_SetQualityTo0_WhenQualityIsAboutToBeLessThan0_ForGeneralItems(int sellIn, int quality)
        {
            var product = new Item {Name = GoodsType.Default, SellIn = sellIn, Quality = quality};
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(0, product.Quality);
        }

        [Test]
        [TestCase(5, 5, 1)]
        [TestCase(-2, 1, 2)]
        public void UpdateQuality_IncreasesTheQuality_WhenSellInDecreased_ForAgedBrie(int sellIn, int quality, int expectedIncrease)
        {
            var product = new Item {Name = GoodsType.AgedBrie, SellIn = sellIn, Quality = quality};
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(quality + expectedIncrease, product.Quality);
        }

        [Test]
        [TestCase(5, 50)]
        [TestCase(-2, 49)]
        public void UpdateQuality_DoesNotIncreaseTheQuality_WhenQualityIsAboutToBeMoreThan50_ForAgedBrie(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.AgedBrie, SellIn = sellIn, Quality = quality };
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        [TestCase(10, 49)]
        [TestCase(5, 48)]
        [TestCase(15, 50)]
        public void UpdateQuality_DoesNotIncreaseTheQuality_WhenQualityIsAboutToBeMoreThan50_ForBackstagePasses(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        [TestCase(5, 80)]
        [TestCase(1, 1)]
        public void UpdateQuality_DoesNotChangeQualityAndSellIn_ForSulfuras(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.Sulfuras, SellIn = sellIn, Quality = quality };
            var items = new List<Item> { product };
            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(sellIn, product.SellIn);
            Assert.AreEqual(quality, product.Quality);
        }

        [Test]
        [TestCase(10, 5)]
        [TestCase(8, 5)]
        public void UpdateQuality_IncreasesTheQualityBy2_WhenSellInEqualsOrLessThan10_ForBackstagePasses(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            var items = new List<Item> { product };

            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(quality + 2, product.Quality);
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(3, 5)]
        public void UpdateQuality_IncreasesTheQualityBy3_WhenSellInEqualsOrLessThan5_ForBackstagePasses(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            var items = new List<Item> { product };

            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(quality + 3, product.Quality);
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(-3, 5)]
        public void UpdateQuality_SetsTheQualityTo0_WhenSellInEqualsOrLessThan0_ForBackstagePasses(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.BackstagePasses, SellIn = sellIn, Quality = quality };

            var items = new List<Item> { product };

            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(0, product.Quality);
        }

        [Test]
        [TestCase(3, 5)]
        [TestCase(1, 50)]
        public void UpdateQuality_DecreasesTheQualityBy2_ForConjured(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.Conjured, SellIn = sellIn, Quality = quality };

            var items = new List<Item> { product };

            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }
            Assert.AreEqual(quality - 2, product.Quality);
        }

        [Test]
        [TestCase(-3, 5)]
        [TestCase(0, 50)]
        public void UpdateQuality_DecreasesTheQualityBy4_WhenSellInLessOrEqualsTo0_ForConjured(int sellIn, int quality)
        {
            var product = new Item { Name = GoodsType.Conjured, SellIn = sellIn, Quality = quality };

            var items = new List<Item> { product };

            foreach (var item in items)
            {
                _strategyProvider.GetDietStrategy(item.Name).UpdateGoods(item);
            }

            Assert.AreEqual(quality - 4, product.Quality);
        }
    }
}