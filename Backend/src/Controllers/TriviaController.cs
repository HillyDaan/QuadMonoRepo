using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("questions")]
public class TriviaController: ControllerBase 
{
  private readonly ITriviaService _triviaService;

  public TriviaController(ITriviaService triviaService){
    _triviaService = triviaService;
  }

  [HttpPost]
  public async Task<ActionResult<ValidateAnswerReponseDTO>> CheckAnswers([FromBody] ValidateAnswerRequestDTO dto) {
    return Ok(await _triviaService.ValidateTriviaQuestions(dto));
  }

  [HttpGet]
  public async Task<ActionResult<TriviaResponseDTO>> GetTriviaQuestions() {
    try
    {
        var result = await _triviaService.GetTriviaQuestions();
        return Ok(result);
    }
    catch (HttpRequestException)
    {
        return StatusCode(503, "Trivia API is currently unavailable.");
    }
    catch (InvalidOperationException)
    {
        return StatusCode(502, "Trivia API returned invalid data.");
    }
  }

}