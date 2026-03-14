public record TriviaResponseDTO(
  string sessionId,
  List<TriviaDTO> Questions
);

public record TriviaDTO(
  string id,
  string question,
  string[] options
);
