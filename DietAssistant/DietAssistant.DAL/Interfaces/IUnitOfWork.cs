using System;
using DietAssistant.Entities;

namespace DietAssistant.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Dish> Dishes { get; }

        IRepository<UserDish> UserDishes { get; }

        IRepository<Report> Reports { get; }

        void Save();
    }
}
