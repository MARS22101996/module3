using System.Collections.Generic;
using Shops.BLL.Dto;
using Shops.BLL.Models;

namespace Shops.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetSortedProducts(FilterModel filters);
    }
}
