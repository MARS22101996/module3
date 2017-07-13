using System.Collections.Generic;

namespace Shops.BLL.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<BrandDto> Brands { get; set; }
    }
}