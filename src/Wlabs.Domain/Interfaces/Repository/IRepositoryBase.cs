using MongoDB.Bson;
using NetDevPack.Data;
using Wlabs.Domain.Entities;

namespace Wlabs.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity>: IRepository<Usuario> where TEntity : EntityBase
    {
        Task<TEntity> ObtemPorId(ObjectId id);
        Task<IEnumerable<TEntity>> ObtemTodos();
        void Insere(TEntity entity);
        void Atualiza(TEntity entity);
        void Remove(TEntity entity);
    }
}
