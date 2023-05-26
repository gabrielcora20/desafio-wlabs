using NetDevPack.Domain;
using Wlabs.Domain.Interfaces;

namespace Wlabs.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public void Atualiza(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Insere(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ObtemPorId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entity>> ObtemTodos()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
