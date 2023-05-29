namespace Wlabs.Domain.Interfaces.Http
{
    public interface IHttpRequester
    {
        Task<TEntity> Get<TEntity>(string url);
    }
}
