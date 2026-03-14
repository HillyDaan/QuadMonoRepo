public record ValidateAnswerReponseDTO(
  string sessionId,
  List<AnswerResponseDTO> Answers
);

public record AnswerResponseDTO(
  string id,
  bool correct
);