using System;
using Shops.BLL.Enums;
using Shops.DAL.Entities;

namespace Shops.BLL.Filtration.Concrete
{
    public class SortFilter : BaseFilter<Func<Product, object>>
    {
        private readonly SortType _sortOption;

        public SortFilter(SortType sortOption)
        {
            _sortOption = sortOption;
        }

        protected override Func<Product, object> Process(Func<Product, object> input)
        {
            switch (_sortOption)
            {
                case SortType.PriceDesc:
                    input = x => x.Price * -1;
                    break;
                case SortType.PriceAsc:
                    input = x => x.Price;
                    break;
            }

            return input;
        }
    }
}