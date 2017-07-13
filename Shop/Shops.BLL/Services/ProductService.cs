using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Shops.BLL.Dto;
using Shops.BLL.Filtration.Concrete;
using Shops.BLL.Interfaces;
using Shops.BLL.Models;
using Shops.DAL.Entities;
using Shops.DAL.Interfaces;

namespace Shops.BLL.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository repository)
        {
            Database = repository;
        
        }
        private IProductRepository Database { get; }

        public IEnumerable<ProductDto> GetSortedProducts(FilterModel filters)
        {
            var gameFilterChain = new ProductFilterChain();
            RegisterFilters(gameFilterChain, filters);
            var sortFilter = new SortFilter(filters.SortType);
            var sortPredicate = sortFilter.Execute(x => x);
            var predicate = gameFilterChain.Execute(x => x.Name != "");
            var filtered = Filtering(predicate);
            var filteredData = sortPredicate != null ? filtered.OrderBy(sortPredicate) : filtered;
            return Mapper.Map<IEnumerable<ProductDto>>(filteredData);
        }

        private static void RegisterFilters(ProductFilterChain gameFilterChain, FilterModel filters)
        {
            gameFilterChain.Register(new ProductBrandFilter(filters.Brands));
            gameFilterChain.Register(new ProductNameFilter(filters.SearchString));
            gameFilterChain.Register(new ProductPriceFilter(filters.MinPrice, filters.MaxPrice));
        }

        private IEnumerable<Product> Filtering(Expression<Func<Product, bool>> filter)
        {
            var query = Database.GetAll().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }
    }
}
