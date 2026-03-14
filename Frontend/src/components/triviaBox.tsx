import type { TriviaDTO } from "#/types/dto/responses/TriviaResponseDTO";
import { TriviaQuestion } from "./triviaQuestion";

interface TriviaBoxProps {
  questions: TriviaDTO[];
}

export function TriviaBox({ questions }: TriviaBoxProps) {
  return (
    <div className="space-y-6">
      {questions.map((question, index) => (
        <TriviaQuestion
          key={index}
          question={question.question}
          options={question.options}
        />
      ))}
    </div>
  );
}