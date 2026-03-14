public class TriviaService: ITriviaService {

  private readonly ITriviaApiService _triviaApiService;
  private readonly ITriviaStorageService _triviaStorageService;

  public TriviaService(
    ITriviaApiService triviaApiService,
    ITriviaStorageService triviaStorageService
  ){
    _triviaApiService = triviaApiService;
    _triviaStorageService = triviaStorageService;
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

   
    await _triviaStorageService.StoreTriviaSession(new TriviaSession
    {
      SessionId = sessionId,
      Questions = storageQuestions
    });

    var dtoQuestions = apiResponse.results
        .Select((q, i) => new TriviaDTO(
            i.ToString(),
            q.question,
            new[] { q.correct_answer }
                .Concat(q.incorrect_answers)
                .ToArray()
        ))
        .ToList();
    return new TriviaResponseDTO(sessionId, dtoQuestions);
  }

}