using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shops.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

    }
}
