using System;
using System.Linq.Expressions;
using Shops.BLL.Filtration.Abstract;
using Shops.DAL.Entities;

namespace Shops.BLL.Filtration.Concrete
{
    public class ProductFilterChain : IFilterChain<Expression<Func<Product, bool>>>
    {
        public IFilter<Expression<Func<Product, bool>>> Root { get; private set; }

        public Expression<Func<Product, bool>> Execute(Expression<Func<Product, bool>> input)
        {
            return Root.Execute(input);
        }

        public IFilterChain<Expression<Func<Product, bool>>> Register(IFilter<Expression<Func<Product, bool>>> filter)
        {
            if (Root == null)
            {
                Root = filter;
            }
            else
            {
                Root.Register(filter);
            }

            return this;
        }
    }
}