using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
