export interface TriviaAnswersRequestDTO {
  sessionId: string,
  Answers: TriviaAnswerDTO[]
}

export interface TriviaAnswerDTO {
  id: string,
  answer: string
}