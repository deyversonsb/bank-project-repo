using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Banking.Common.Application.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Banking.Common.Infrastructure.Caching;
internal sealed class CacheService(IDistributedCache cache) : ICacheService
{
    public async Task<T?> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default)
    {
        byte[]? bytes = await cache.GetAsync(cacheKey, cancellationToken);

        return bytes is null ? default : Deserialize<T>(bytes);
    }
    public Task SetAsync<T>(
        string cacheKey,
        T value,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        byte[] bytes = Serialize(value);

        return cache.SetAsync(cacheKey, bytes, CacheOptions.Create(expiration), cancellationToken);
    }
    public Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default) 
        => cache.RemoveAsync(cacheKey, cancellationToken);

    private static T Deserialize<T>(byte[] bytes)
        => JsonSerializer.Deserialize<T>(bytes)!;

    private static byte[] Serialize<T>(T value)
    {
        var buffer = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(buffer);
        JsonSerializer.Serialize(writer, value);
        return buffer.WrittenSpan.ToArray();
    }
}
