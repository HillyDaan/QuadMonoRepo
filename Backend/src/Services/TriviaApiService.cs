public class TriviaApiService: ITriviaApiService {
  private readonly HttpClient _httpClient;
  private readonly string _openTriviaUrl;

  public TriviaApiService(HttpClient httpClient, IConfiguration configuration){
    _httpClient = httpClient;
    _openTriviaUrl = configuration["TriviaApi:OpenTriviaUrl"]!;
  }

  public async Task<OpenTriviaDTO> GetTriviaQuestionsOpenTrivia()
  {
      var response = await _httpClient.GetAsync(_openTriviaUrl);
      response.EnsureSuccessStatusCode();
      var data = await response.Content.ReadFromJsonAsync<OpenTriviaDTO>();

      if (data is null)
          throw new InvalidOperationException("OpenTrivia API returned an empty response.");

      return data;
  }
}