﻿namespace Wlabs.Domain.Interfaces.Http
{
    public interface IHttpRequester
    {
        Task<TEntity> Get<TEntity>(string url) where TEntity : class;
        Task<TEntity> GetAndCache<TEntity>(string url, string cacheKey) where TEntity : class;
    }
}
