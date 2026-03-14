public record ValidateAnswerReponseDTO(
  string sessionId,
  List<AnswerDTO> Answers
);

public record AnswerDTO(
  string id,
  bool correct
);