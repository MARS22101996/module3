using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Shop.Infrastructure.Automapper;
using Shops.BLL.Enums;
using Shops.BLL.Models;
using Shops.BLL.Services;
using Shops.DAL.Entities;
using Shops.DAL.Interfaces;

namespace Shop.Test
{
    public class Tests
    {
        private Mock<IProductRepository> _mock;
        private ProductService _serv;


        [SetUp]
        public void SetupContext()
        {
            AutoMapperConfiguration.Configure();
            _mock = new Mock<IProductRepository>();
            _serv = new ProductService(_mock.Object);;
        }

        [Test]
        public void GetFiltered_FilterParametrs_PageParametrs_Get()
        {
            var filterDto = new FilterModel
            {
                Brands = new List<string> { "Test-Brand-1" , "Test-Brand-1" },
                SearchString = "tes",
                SortType = SortType.PriceAsc, 
                MinPrice = 0,
                MaxPrice = 100,
            };
            _mock.Setup(
                mr =>
                    mr.GetAll()).Returns(new List<Product> { new Product() {Id = 1, Name = "test", Price = 100, Brands = new List<Brand> {new Brand {Id = 1, Name = "Test-Brand-1" } } } });

            var gamesAfteFilter = _serv.GetSortedProducts(filterDto);

            Assert.AreEqual(gamesAfteFilter.Count(),1);
        }
    }
}
