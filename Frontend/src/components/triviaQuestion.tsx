import { useState } from "react";
import { Button } from "./ui/button";
import { Card, CardContent } from './ui/card';
import { decodeHtml } from "#/lib/utils";

interface TriviaQuestionProps {
  question: string;
  options: string[];
}

export function TriviaQuestion({ question, options }: TriviaQuestionProps) {
  const [selected, setSelected] = useState<string | null>(null);

  return (
    <Card className="p-4 shadow-md border rounded-md">
      <CardContent>
        <h2 className="text-lg font-semibold mb-4">{decodeHtml(question)}</h2>
        <div className="flex flex-col space-y-2">
          {options.map((option, index) => (
            <Button
              key={index}
              variant={selected === option ? "default" : "outline"}
              onClick={() => setSelected(decodeHtml(option))}
            >
              {option}
            </Button>
          ))}
        </div>
      </CardContent>
    </Card>
  );
}