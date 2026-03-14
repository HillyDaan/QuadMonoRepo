public interface ITriviaService {
  Task<TriviaResponseDTO> GetTriviaQuestions();

  Task<ValidateAnswerReponseDTO> ValidateTriviaQuestions(ValidateAnswerRequestDTO dto);
}