using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TriviaServiceTests
{
    [Fact]
    public async Task ValidateTriviaQuestions_ReturnsCorrectResults()
    {
        var mockStorage = new Mock<ITriviaStorageService>();
        var mockApi = new Mock<ITriviaApiService>();

        var session = new TriviaSession
        {
            SessionId = "test-session",
            Questions = new List<Question>
            {
                new Question { Id = "1", QuestionText = "Q1", CorrectAnswer = "A" },
                new Question { Id = "2", QuestionText = "Q2", CorrectAnswer = "B" }
            }
        };

        mockStorage.Setup(s => s.GetTriviaSession("test-session"))
                   .ReturnsAsync(session);

        var service = new TriviaService(mockApi.Object, mockStorage.Object);

        var dto = new ValidateAnswerRequestDTO(
            "test-session",
            new List<Answer>
            {
                new Answer("1", "A"), // correct
                new Answer("2", "C")  // incorrect
            }
        );

        var result = await service.ValidateTriviaQuestions(dto);

        Assert.Equal("test-session", result.sessionId);
        Assert.Equal(2, result.Answers.Count);
        Assert.True(result.Answers[0].correct);
        Assert.False(result.Answers[1].correct);
        Assert.Equal("B", result.Answers[1].correctAnswer);
    }

    [Fact]
    public async Task ValidateTriviaQuestions_Throws_WhenSessionNotFound()
    {
        var mockStorage = new Mock<ITriviaStorageService>();
        var mockApi = new Mock<ITriviaApiService>();

        mockStorage.Setup(s => s.GetTriviaSession(It.IsAny<string>()))
                   .ReturnsAsync((TriviaSession?)null);

        var service = new TriviaService(mockApi.Object, mockStorage.Object);

        var dto = new ValidateAnswerRequestDTO("missing-session", new List<Answer>());

        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await service.ValidateTriviaQuestions(dto);
        });
    }
}