import { Button } from "./ui/button";
import { Card, CardContent } from './ui/card';
import { decodeHtml } from "#/lib/utils";

interface TriviaQuestionProps {
  question: string;
  options: string[];
  selected: string | null;
  onSelect: (option: string) => void;
}

export function TriviaQuestion({ question, options, selected, onSelect }: TriviaQuestionProps) {
  return (
    <Card className="p-4 shadow-md border rounded-md">
      <CardContent>
        <h2 className="text-lg font-semibold mb-4">{decodeHtml(question)}</h2>
        <div className="flex flex-col space-y-2">
          {options.map((option) => {
            const decoded = decodeHtml(option);
            return (
              <Button
                key={decoded}
                variant={selected === decoded ? "default" : "outline"}
                onClick={() => onSelect(decoded)}
              >
                {decoded}
              </Button>
            );
          })}
        </div>
      </CardContent>
    </Card>
  );
}