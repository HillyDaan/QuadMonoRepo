public class TriviaSession
{
    public required string SessionId { get; set; }
    public required  List<Question> Questions { get; set; }
}

public class Question
{
    public required  string Id { get; set; }
    public required  string QuestionText { get; set; }
    public required  string CorrectAnswer { get; set; }
}