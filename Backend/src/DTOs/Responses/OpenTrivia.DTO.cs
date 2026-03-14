public class OpenTriviaDTO
{
    public required  int response_code { get; set; }
    public required  List<TriviaQuestionDTO> results { get; set; }
}

public class TriviaQuestionDTO
{
    public required  string type { get; set; }
    public required  string difficulty { get; set; }
    public required  string category { get; set; }
    public required  string question { get; set; }
    public required  string correct_answer { get; set; }
    public required List<string> incorrect_answers { get; set; }
}