using System;
using System.Linq.Expressions;
using Shops.DAL.Entities;
using Shops.BLL.Infrastructure;

namespace Shops.BLL.Filtration.Concrete
{

    public class ProductNameFilter : BaseFilter<Expression<Func<Product, bool>>>
    {
        private readonly string _searchString;

        public ProductNameFilter(string searchString)
        {
            _searchString = searchString;
        }

        protected override Expression<Func<Product, bool>> Process(Expression<Func<Product, bool>> input)
        {
            return string.IsNullOrEmpty(_searchString)
                ? input
                : input.And(x => x.Name.ToLower().Contains(_searchString.ToLower()));
        }
    }
}