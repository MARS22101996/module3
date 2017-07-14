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
        private readonly FilterModel _filterSuccessModel;
        private readonly FilterModel _filterFailModel;
        private IEnumerable<ProductDto> _resultSuccess;
        private IEnumerable<ProductDto> _resultFail;

        public FilteringProductsSteps()
        {
            AutoMapperConfiguration.Configure();
            var mock = new Mock<IProductRepository>();
            _serv = new ProductService(mock.Object);
            _filterSuccessModel = new FilterModel();
            _filterFailModel = new FilterModel();
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

        [Given(@"If brand's products exist I have entered brand (.*)")]
        public void GivenIfBrandSProductsExistIHaveEnteredBrandTestbrand_(string brand)
        {
            _filterSuccessModel.Brands = new List<string> { brand };
        }

        [Given(@"if brand's products do not exist I have entered brand (.*)")]
        public void GivenIfBrandSProductsDoNotExistIHaveEnteredBrandTestbrand_(string brand)
        {
            _filterFailModel.Brands = new List<string> { brand };
        }

        [Given(@"If products with this price exist I have entered min price (.*) and max price (.*)")]
        public void GivenIfProductsWithThisPriceExistIHaveEnteredMinPriceAndMaxPrice(decimal min, decimal max)
        {
            _filterSuccessModel.MinPrice = min;
            _filterSuccessModel.MaxPrice = max;
            _filterSuccessModel.Brands = new List<string>();
        }

        [Given(@"If products with this price do not exist I have entered min price (.*) and max price (.*)")]
        public void GivenIfProductsWithThisPriceDoNotExistIHaveEnteredMinPriceAndMaxPrice(decimal min, decimal max)
        {
            _filterFailModel.MinPrice = min;
            _filterFailModel.MaxPrice = max;
            _filterFailModel.Brands = new List<string>();
        }

        [Given(@"If products with this name exist I have entered name (.*) in the searchstring")]
        public void GivenIfProductsWithThisNameExistIHaveEnteredNameTestnameInTheSearchstring(string name)
        {
            _filterSuccessModel.SearchString = name;
            _filterSuccessModel.Brands = new List<string>();
        }

        [Given(@"If products with this name do not exist I have entered name (.*) in the searchstring")]
        public void GivenIfProductsWithThisNameDoNotExistIHaveEnteredNameUnknownnameInTheSearchstring(string name)
        {
            _filterFailModel.SearchString = name;
            _filterFailModel.Brands = new List<string>();
        }

        [When(@"I press search if necessary products exist")]
        public void WhenIPressSearchIfNecessaryProductsExist()
        {
            _resultSuccess = _serv.GetSortedProducts(_filterSuccessModel);
        }

        [When(@"I press search if necessary products do not exist")]
        public void WhenIPressSearchIfNecessaryProductsDoNotExist()
        {
            _resultFail = _serv.GetSortedProducts(_filterFailModel);
        }

        [Then(@"Get products if necessary products exist")]
        public void ThenGetProductsIfNecessaryProductsExist()
        {
            Assert.AreEqual(_resultSuccess.Count(), 1);
        }

        [Then(@"Do not get products if necessary products do not exist")]
        public void ThenDoNotGetProductsIfNecessaryProductsDoNotExist()
        {
            Assert.AreEqual(_resultFail.Count(), 0);
        }
    }
}