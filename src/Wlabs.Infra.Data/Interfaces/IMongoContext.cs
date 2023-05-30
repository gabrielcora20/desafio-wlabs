using MongoDB.Driver;
using NetDevPack.Data;
using Wlabs.Domain.Entities;

namespace Wlabs.Infra.Data.Interfaces
{
    public interface IMongoContext : IDisposable, IUnitOfWork
    {
        void AddCommand(Func<Task> func, EntityBase entity);
        Task<int> SaveChanges();
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
