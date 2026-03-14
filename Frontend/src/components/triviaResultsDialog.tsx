import { Dialog, DialogContent, DialogTitle, DialogFooter } from '#/components/ui/dialog';
import type { TriviaDTO } from '#/types/dto/responses/TriviaResponseDTO';
import { decodeHtml } from '#/lib/utils';
import type { TriviaAnswersResponseDTO } from '#/types/dto/responses/TriviaAnswersResponseDTO';
import { Button } from './ui/button';

interface Props {
  open: boolean;
  onOpenChange: (open: boolean) => void;
  results: TriviaAnswersResponseDTO;
  questions: TriviaDTO[];
}

export function TriviaResultsDialog({ open, onOpenChange, results, questions }: Props) {
  const totalCorrect = results.answers.filter(a => a.correct).length;

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent>
        <DialogTitle>Results</DialogTitle>
        <div className="py-2 space-y-2">
          <p className="font-semibold">
            You got {totalCorrect} / {results.answers.length} correct
          </p>

          {results.answers.filter(a => !a.correct).map(a => {
            const question = questions.find(q => q.id === a.id);
            return (
              <div key={a.id} className="p-2 border rounded-md bg-muted/10">
                <p className="font-semibold">{decodeHtml(question?.question || '')}</p>
                <p className="text-red-600">Correct answer: {decodeHtml(a.correctAnswer || '')}</p>
              </div>
            );
          })}
        </div>
        <DialogFooter>
          <Button onClick={() => onOpenChange(false)}>Close</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}