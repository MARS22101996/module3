using System;
using System.Linq.Expressions;
using Shops.DAL.Entities;
using Shops.BLL.Infrastructure;

namespace Shops.BLL.Filtration.Concrete
{

    public class ProductPriceFilter : BaseFilter<Expression<Func<Product, bool>>>
    {
        private readonly decimal? _maxPrice;

        private readonly decimal? _minPrice;

        public ProductPriceFilter(decimal? minPrice, decimal? maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        protected override Expression<Func<Product, bool>> Process(Expression<Func<Product, bool>> input)
        {
            if (_minPrice != null && _maxPrice != null)
            {
                input = input.And(x => x.Price >= _minPrice && x.Price <= _maxPrice);
            }
            else if (_minPrice != null)
            {
                input = input.And(x => x.Price >= _minPrice);
            }
            else if (_maxPrice != null)
            {
                input = input.And(x => x.Price <= _maxPrice);
            }

            return input;
        }
    }
}