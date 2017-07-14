using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Infrastructure.Automapper;
using Shops.BLL.Dto;
using Shops.BLL.Models;
using Shops.BLL.Services;
using Shops.DAL.Entities;
using Shops.DAL.Interfaces;
using TechTalk.SpecFlow;

namespace Shop.Test.TestDefinitions
{
    [Binding]
    public class FilteringProductsSteps
    {
        private readonly ProductService _serv;
        private readonly FilterModel _filterModel;
        private IEnumerable<ProductDto> _result;

        public FilteringProductsSteps()
        {
            AutoMapperConfiguration.Configure();
            var mock = new Mock<IProductRepository>();
            _serv = new ProductService(mock.Object);
            _filterModel = new FilterModel();
            mock.Setup(
                mr =>
                    mr.GetAll()).Returns(new List<Product>
            {
                new Product
                {
                    Name = " testname",
                    Price = 100,
                    Brands = new List<Brand> {new Brand {Id = 1, Name = " testbrand_1"}}
                }
            });
        }
        [Given(@"I have entered brand (.*)")]
        public void GivenIHaveEnteredBrand(string brand)
        {
            _filterModel.Brands = new List<string> { brand };
        }

        [Given(@"I have entered min price (.*) and max price (.*)")]
        public void GivenIHaveEnteredMinPriceAndMaxPrice(decimal min, decimal max)
        {
            _filterModel.MinPrice = min;
            _filterModel.MaxPrice = max;
            _filterModel.Brands = new List<string>();
        }

        [Given(@"I have entered name (.*) in the searchstring")]
        public void GivenIHaveEnteredNameInTheSearchstring(string name)
        {
            _filterModel.SearchString = name;
            _filterModel.Brands = new List<string>();
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            _result = _serv.GetSortedProducts(_filterModel);
        }

        [Then(@"Get products if necessary products exist")]
        public void ThenGetProductsIfNecessaryProductsExist()
        {
            Assert.AreEqual(_result.Count(), 1);
        }

        [Then(@"Do not get products if necessary products do not exist")]
        public void ThenDoNotGetProductsIfNecessaryProductsDoNotExist()
        {
            Assert.AreEqual(_result.Count(), 0);
        }
    }
}