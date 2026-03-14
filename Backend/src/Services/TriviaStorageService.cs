public class TriviaStorageService : ITriviaStorageService {

  private readonly IStorageProvider _provider;
  private readonly int  _defaultTimeout = 1000 * 60 * 10; //10 minutes

  public TriviaStorageService(IStorageProvider provider) {
    _provider = provider;
  }

  public async Task StoreTriviaSession(TriviaSession session)
  {
      await _provider.SaveTriviaSession(session, _defaultTimeout);
  }

  public async Task<TriviaSession?> GetTriviaSession(string sessionId)
  {
      return await _provider.GetTriviaSession(sessionId);
  }

  public async Task DeleteTriviaSession(string sessionId)
  {
      await _provider.DeleteTriviaSession(sessionId);
  }
}