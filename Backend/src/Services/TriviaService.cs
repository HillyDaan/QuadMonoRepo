public class TriviaService: ITriviaService {

  private readonly ITriviaApiService _triviaApiService;

  public TriviaService(ITriviaApiService triviaApiService){
    _triviaApiService = triviaApiService;
  }

  public async Task<TriviaResponseDTO> GetTriviaQuestions(){

    var apiResponse = await _triviaApiService.GetTriviaQuestionsOpenTrivia();

    string sessionId = Guid.NewGuid().ToString();
    var storageQuestions = apiResponse.results
      .Select((q, i) => new Question
      {
          Id = i.ToString(),
          QuestionText = q.question,
          CorrectAnswer = q.correct_answer
      })
      .ToList();

    //Store these ^
    var dtoQuestions = apiResponse.results
        .Select((q, i) => new TriviaDTO(
            i.ToString(),
            q.question,
            new[] { q.correct_answer }
                .Concat(q.incorrect_answers)
                .ToArray()
        ))
        .ToList();
    //Return these ^
    return new TriviaResponseDTO(sessionId, dtoQuestions);
  }

}