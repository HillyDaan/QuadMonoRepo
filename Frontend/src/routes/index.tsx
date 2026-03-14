import { TriviaBox } from '#/components/triviaBox';
import { useTriviaSession, useValidateTriviaAnswers } from '#/hooks/triviaApiHooks'
import { createFileRoute } from '@tanstack/react-router'
import '../styles.css';
import type { TriviaAnswersRequestDTO } from '#/types/dto/requests/TriviaAnswersRequestDTO';
import type { TriviaAnswersResponseDTO } from '#/types/dto/responses/TriviaAnswersResponseDTO';
import { useState } from 'react';
import { TriviaResultsDialog } from '#/components/triviaResultsDialog';

export const Route = createFileRoute('/')({ component: App })

function App() {

  const { data, isLoading, isError } = useTriviaSession();
  const validateMutation = useValidateTriviaAnswers();

  const [results, setResults] = useState<TriviaAnswersResponseDTO | null>(null);
  const [open, setOpen] = useState(false);
  
  if(isLoading) {
    return (
      <div>
        loading
      </div>
    )
  }

  if (isError || !data) {
    return (
      <div className="text-center text-muted-foreground py-10">
        Failed to load trivia session
        {isError}
      </div>
    );
  }

  function onSubmitAnswers(answers: Record<string, string>){
    const dto: TriviaAnswersRequestDTO = {
      sessionId: data?.sessionId!,
      Answers: Object.entries(answers).map(([id, answer]) => ({ id, answer }))
    }
    validateMutation.mutate(dto, {
      onSuccess(response) {
        setResults(response);
        setOpen(true);
      },
      onError(error) {
        console.error('Failed to validate', error)
      }
    })
  }

  return (
    <main className="page-wrap px-4 pb-8 pt-14">
      <TriviaBox questions={data.questions} onSubmit={onSubmitAnswers}/>
      {results && (
        <TriviaResultsDialog
          open={open}
          onOpenChange={setOpen}
          results={results}
          questions={data.questions}
        />
      )}
    
    </main>
  )
}
