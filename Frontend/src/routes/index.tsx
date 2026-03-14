import { TriviaBox } from '#/components/triviaBox';
import { useTriviaSession } from '#/hooks/triviaApiHooks'
import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/')({ component: App })

function App() {

  const { data, isLoading, isError } = useTriviaSession();

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
  return (
    <main className="page-wrap px-4 pb-8 pt-14">
      <TriviaBox questions={data.questions} />
    </main>
  )
}
