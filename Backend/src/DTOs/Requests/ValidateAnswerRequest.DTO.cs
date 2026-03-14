public record ValidateAnswerRequestDTO(
  string sessionId,
  List<Answer> Answers
);

public record Answer(
  string id,
  string answer
);

