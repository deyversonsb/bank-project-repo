using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Common.Application.Caching;
public interface ICacheService
{
    Task<T?> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default);

    Task SetAsync<T>(
        string cacheKey,
        T value,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default);
}
