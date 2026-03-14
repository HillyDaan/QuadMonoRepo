public interface ITriviaStorageService {
    Task StoreTriviaSession(TriviaSession session);
    Task<TriviaSession?> GetTriviaSession(string sessionId);
    Task DeleteTriviaSession(string sessionId);
}