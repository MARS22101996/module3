using System.Collections.Generic;
using Shops.BLL.Enums;

namespace Shops.BLL.Models
{
    public class FilterModel
    {
        public List<string> Brands { get; set; }

        public string SearchString { get; set; }

        public SortType SortType { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}
