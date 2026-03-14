using Microsoft.Extensions.Caching.Memory;
using Xunit;

public class InMemoryServiceTests
{
    [Fact]
    public async Task StoreAndGetTriviaSession_WorksCorrectly()
    {
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var provider = new InMemoryStorageProvider(memoryCache);
        var storageService = new TriviaStorageService(provider);

        var session = new TriviaSession
        {
            SessionId = "session-1",
            Questions = new List<Question> { new Question { Id = "1", QuestionText = "Q", CorrectAnswer = "A" } }
        };

        await storageService.StoreTriviaSession(session);

        var retrieved = await storageService.GetTriviaSession("session-1");

        Assert.NotNull(retrieved);
        Assert.Equal("session-1", retrieved!.SessionId);
        Assert.Single(retrieved.Questions);
    }

    [Fact]
    public async Task StoreGetDelete_TriviaSession_WorksCorrectly()
    {
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var provider = new InMemoryStorageProvider(memoryCache);
        var storageService = new TriviaStorageService(provider);

        var session = new TriviaSession
        {
            SessionId = "test-session",
            Questions = new List<Question>
            {
                new Question { Id = "1", QuestionText = "Q1", CorrectAnswer = "A" }
            }
        };

        await storageService.StoreTriviaSession(session);

        var retrieved = await storageService.GetTriviaSession("test-session");
        Assert.NotNull(retrieved);
        Assert.Equal("test-session", retrieved!.SessionId);
        Assert.Single(retrieved.Questions);

        await storageService.DeleteTriviaSession("test-session");

        //Should be deledted here
        var deleted = await storageService.GetTriviaSession("test-session");
        Assert.Null(deleted);
    }
}