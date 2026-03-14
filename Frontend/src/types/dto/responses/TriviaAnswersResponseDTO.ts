export interface TriviaAnswersResponseDTO {
  sessionId: string,
  answers: TriviaAnswerDTO[]
}

export interface TriviaAnswerDTO {
  id: string,
  correct: boolean,
  correctAnswer?: string,
}