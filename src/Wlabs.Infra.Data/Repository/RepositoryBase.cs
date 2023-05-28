using MongoDB.Bson;
using MongoDB.Driver;
using NetDevPack.Data;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Context;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IMongoContext Context;
        protected readonly IMongoCollection<TEntity> DbSet;
        public RepositoryBase(IMongoContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public IUnitOfWork UnitOfWork => Context;

        public virtual void Atualiza(TEntity entity)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity), entity);
        }

        public virtual void Insere(TEntity entity)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(entity), entity);
        }

        public virtual async Task<TEntity> ObtemPorId(ObjectId id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> ObtemTodos()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId())), entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
