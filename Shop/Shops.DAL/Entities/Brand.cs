using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shops.DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
