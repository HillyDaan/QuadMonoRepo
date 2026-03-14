public class TriviaApiService: ITriviaApiService {
  private readonly HttpClient _httpClient;

  public TriviaApiService(HttpClient httpClient){
    _httpClient = httpClient;
  }

  public async Task<OpenTriviaDTO> GetTriviaQuestionsOpenTrivia()
  {
      const string url = "https://opentdb.com/api.php?amount=5";

      var response = await _httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();
      var data = await response.Content.ReadFromJsonAsync<OpenTriviaDTO>();

      if (data is null)
          throw new InvalidOperationException("OpenTrivia API returned an empty response.");

      return data;
  }
}