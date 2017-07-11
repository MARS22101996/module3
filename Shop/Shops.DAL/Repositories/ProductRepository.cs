using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public virtual IEnumerable<Product> Get(Expression<Func<Product, bool>> predicate, Func<Product, object> sortPredicate)
        {
            var filtered = Filtering(predicate);

            IEnumerable<Product> sorted;

            if (sortPredicate != null)
            {
                sorted = filtered.OrderBy(sortPredicate);
            }
            else
            {
                sorted = filtered;
            }
            return sorted;
        }

        private IQueryable<Product> Filtering(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = GetAll().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
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
