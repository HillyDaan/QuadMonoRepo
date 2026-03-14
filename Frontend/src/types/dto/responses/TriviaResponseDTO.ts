export interface TriviaResponseDTO {
  sessionId: string;
  questions: TriviaDTO[]
}

export interface TriviaDTO {
  id: string,
  question: string,
  options: string[]
}
