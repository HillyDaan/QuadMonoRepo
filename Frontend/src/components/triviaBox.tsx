import type { TriviaDTO } from "#/types/dto/responses/TriviaResponseDTO";
import { useState } from "react";
import { TriviaQuestion } from "./triviaQuestion";
import { Button } from "./ui/button";

interface TriviaBoxProps {
  questions: TriviaDTO[];
  onSubmit?: (answers: Record<string, string>) => void;
}


export function TriviaBox({ questions, onSubmit }: TriviaBoxProps) {
  const [selectedAnswers, setSelectedAnswers] = useState<Record<string, string>>({});

  const handleSelect = (questionId: string, option: string) => {
    setSelectedAnswers(prev => ({ ...prev, [questionId]: option }));
  };

  const handleSubmit = () => {
    if (onSubmit) {
      onSubmit(selectedAnswers);
    } else {
      console.log("Selected answers:", selectedAnswers);
    }
  };

  return (
    <div className="space-y-6">
      {questions.map((question) => (
        <TriviaQuestion
          key={question.id}
          question={question.question}
          options={question.options}
          selected={selectedAnswers[question.id] || null}
          onSelect={(option) => handleSelect(question.id, option)}
        />
      ))}

      <Button className="mt-4" onClick={handleSubmit}>
        Check Answers
      </Button>
    </div>
  );
}