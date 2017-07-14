using System.Collections.Generic;
using Shops.DAL.Entities;

namespace Shops.DAL.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product item);

        void Update(Product item);

        void Delete(int id);

        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void Save();
    }
}
