using System;
using System.Data.Entity;
using System.Linq;
using DietAssistant.Context;
using DietAssistant.Interfaces;

namespace DietAssistant.Repositories
{
    public class CommonRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DietAssistantContext Context;

        public CommonRepository(DietAssistantContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public virtual void Create(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        public virtual void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var set = Context.Set<TEntity>();
            var item = set.Find(id);
            if (item == null) return;
            set.Remove(item);
        }
    }
}
