using NetDevPack.Domain;

namespace Wlabs.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> ObtemPorId(string id);
        Task<IEnumerable<Entity>> ObtemTodos();
        void Insere(TEntity entity);
        void Atualiza(TEntity entity);
        void Remove(TEntity entity);
    }
}
