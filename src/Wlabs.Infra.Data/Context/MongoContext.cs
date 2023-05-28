using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Wlabs.Domain.Interfaces.Context;
using NetDevPack.Mediator;
using Wlabs.Domain.Entities;

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
            var tasks = new List<Task>() { domainCommand.Command() };

            var domainEvents = domainCommand
                .Entity
                .DomainEvents
                .ToList();
            
            domainCommand.Entity.ClearDomainEvents();

            return tasks.Concat(
                domainEvents
                    .Select(async (domainEvent) => {
                        await _mediatorHandler.PublishEvent(domainEvent);
                    }));
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);

            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<TEntity>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func, EntityBase entity)
        {
            _domainCommands.Add(new DomainCommand(func, entity));
        }

        public async Task<bool> Commit()
        {
            return await SaveChanges() > 0;
        }
    }
}
