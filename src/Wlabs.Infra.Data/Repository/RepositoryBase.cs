using MongoDB.Bson;
using MongoDB.Driver;
using NetDevPack.Data;
using Serilog;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.Data.Interfaces;

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
            try
            {
                Log.Information($"Executando o método {nameof(Atualiza)} na classe: {GetType().Name}");

                Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity), entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(Atualiza)} na classe: {GetType().Name}");
                throw;
            }
        }

        public virtual void Insere(TEntity entity)
        {
            try
            {
                Log.Information($"Executando o método {nameof(Insere)} na classe: {GetType().Name}");

                Context.AddCommand(() => DbSet.InsertOneAsync(entity), entity);

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(Insere)} na classe: {GetType().Name}");
                throw;
            }
        }

        public virtual async Task<TEntity> ObtemPorId(ObjectId id)
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemPorId)} na classe: {GetType().Name}");

                var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
                return data.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemPorId)} na classe: {GetType().Name}");
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> ObtemTodos()
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemTodos)} na classe: {GetType().Name}");

                var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
                return all.ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemTodos)} na classe: {GetType().Name}");
                throw;
            }
        }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                Log.Information($"Executando o método {nameof(Remove)} na classe: {GetType().Name}");

                Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId())), entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(Remove)} na classe: {GetType().Name}");
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
