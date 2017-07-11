using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shops.DAL.Entities;
using Shops.BLL.Infrastructure;

namespace Shops.BLL.Filtration.Concrete
{
    public class ProductBrandFilter : BaseFilter<Expression<Func<Product, bool>>>
    {
        private List<string> Brands { get; set; }

        public ProductBrandFilter(List<string> brands)
        {
            Brands = brands;
        }
        protected override Expression<Func<Product, bool>> Process(Expression<Func<Product, bool>> input)
        {
            return Brands.Count != 0 ? input.And(x => x.Brands.Any(genre => Brands.Contains(genre.Name))) : input;
        }
    }
}