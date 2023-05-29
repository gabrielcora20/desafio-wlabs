using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Wlabs.Domain.Interfaces.Context;
using NetDevPack.Mediator;
using Wlabs.Domain.Entities;
using Serilog;

namespace Wlabs.Infra.Data.Context
{
    public sealed class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<DomainCommand> _domainCommands;
        private readonly IConfiguration _configuration;
        private readonly IMediatorHandler _mediatorHandler;
        public MongoContext(IConfiguration configuration, IMediatorHandler mediatorHandler)
        {
            _configuration = configuration;
            _mediatorHandler = mediatorHandler;
            _domainCommands = new List<DomainCommand>();
        }

        public async Task<int> SaveChanges()
        {
            Log.Information($"Executando o método {nameof(SaveChanges)} na classe: {typeof(MongoContext).Name}");

            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();
                await Task.WhenAll(_domainCommands.SelectMany(d => PublishDomainEvents(d)));
                await Session.CommitTransactionAsync();
            }

            return _domainCommands.Count;
        }


        private IEnumerable<Task> PublishDomainEvents(DomainCommand domainCommand)
        {
            Log.Information($"Executando o método {nameof(PublishDomainEvents)} na classe: {typeof(MongoContext).Name}");

            var tasks = new List<Task>() { domainCommand.Command() };

            var domainEvents = domainCommand
                .Entity
                .DomainEvents
                .ToList();

            domainCommand.Entity.ClearDomainEvents();

            return tasks.Concat(
                domainEvents
                    .Select(async (domainEvent) =>
                    {
                        await _mediatorHandler.PublishEvent(domainEvent);
                    }));
        }

        private void ConfigureMongo()
        {
            try
            {
                Log.Information($"Executando o método {nameof(ConfigureMongo)} na classe: {GetType().Name}");

                if (MongoClient != null)
                {
                    return;
                }

                MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);

                Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);

                Log.Information($"Banco de dados MongoDB conectado");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Houve um problema ao conectar-se no banco de dados MongoDB");
                throw;
            }
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            Log.Information($"Executando o método {nameof(GetCollection)} na classe: {typeof(MongoContext).Name}");

            ConfigureMongo();
            return Database.GetCollection<TEntity>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func, EntityBase entity)
        {
            Log.Information($"Executando o método {nameof(AddCommand)} na classe: {typeof(MongoContext).Name}");

            _domainCommands.Add(new DomainCommand(func, entity));
        }

        public async Task<bool> Commit()
        {
            Log.Information($"Executando o método {nameof(Commit)} na classe: {typeof(MongoContext).Name}");

            return await SaveChanges() > 0;
        }
    }
}
