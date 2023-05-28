using Wlabs.Domain.Entities;

namespace Wlabs.Infra.Data.Context
{
    public class DomainCommand
    {
        public Func<Task> Command { get; private set; }
        public EntityBase Entity { get; private set; }

        public DomainCommand(Func<Task> command, EntityBase entity)
        {
            Command = command;
            Entity = entity;
        }
    }
}
