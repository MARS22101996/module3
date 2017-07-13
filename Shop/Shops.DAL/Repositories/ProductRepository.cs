using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Shops.DAL.Context;
using Shops.DAL.Entities;
using Shops.DAL.Interfaces;

namespace Shops.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.Products.Find(id);
            if (item == null) return;
            _context.Products.Remove(item);
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}
