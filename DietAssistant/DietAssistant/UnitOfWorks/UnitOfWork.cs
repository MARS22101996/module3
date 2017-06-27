using DietAssistant.Context;
using DietAssistant.Entities;
using DietAssistant.Interfaces;
using DietAssistant.Repositories;
using System.Configuration;

namespace DietAssistant.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private DietAssistantContext _db;

        private IRepository<User> _userRepository;

        private IRepository<Dish> _dishRepository;

        private IRepository<UserDish> _userDishRepository;

        private IRepository<Report> _reportRepository;

        public UnitOfWork(DietAssistantContext context)
        {        
            _db = context;
        }

        public IRepository<User> Users => _userRepository ?? (_userRepository = new CommonRepository<User>(_db));

        public IRepository<Dish> Dishes => _dishRepository ?? (_dishRepository = new CommonRepository<Dish>(_db));

        public IRepository<UserDish> UserDishes => _userDishRepository ?? (_userDishRepository = new CommonRepository<UserDish>(_db));

        public IRepository<Report> Reports => _reportRepository ?? (_reportRepository = new CommonRepository<Report>(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db == null) return;
            _db.Dispose();
            _db = null;
        }
    }
}
