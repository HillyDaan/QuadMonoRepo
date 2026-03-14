public interface IStorageProvider {
  Task SaveTriviaSession(TriviaSession session, int timeout);
  Task<TriviaSession?> GetTriviaSession(string sessionId);

  Task DeleteTriviaSession(string sesionId);
}