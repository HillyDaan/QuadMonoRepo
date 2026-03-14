public interface ITriviaService {
  Task<TriviaResponseDTO> GetTriviaQuestions();
}