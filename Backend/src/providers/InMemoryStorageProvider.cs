using Microsoft.Extensions.Caching.Memory;
public class InMemoryStorageProvider : IStorageProvider
{
  private readonly IMemoryCache _cache;
  public InMemoryStorageProvider(IMemoryCache cache)
  {
    _cache = cache;
  }
  public Task SaveTriviaSession(TriviaSession session, int timeout)
  {
    var options = new MemoryCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(timeout)
    };

    _cache.Set(session.SessionId, session, options);
    
    return Task.CompletedTask;
  }

  public Task<TriviaSession?> GetTriviaSession(string sessionId)
  {
    _cache.TryGetValue(sessionId, out TriviaSession? session);
    return Task.FromResult(session);
  }

  public Task DeleteTriviaSession(string sessionId)
  {
    _cache.Remove(sessionId);
    return Task.CompletedTask;
  }
}