# Quad Solutions Assesment

# Visit the site live (Hosted on Railway)

Frontend: https://quadmonorepo-frontend-production.up.railway.app/
Backend api:  https://quadmonorepo-production.up.railway.app/

## Building the application
### Backend
- (Make sure you have .NET 10)
- Navigate to Backend folder
- dotnet run

### Frontend
- (Make sure you have > Node 20)
- Navigate to Frontend folder
- Install dependencies: npm i
- Prepare ENV file:
  - Make a .env file in the Frontend folder
  - Add this line: VITE_TRIVIA_BACKEND_API=http://localhost:5136
  - Change port to the port currently running your c# backend
- Run dev server: npm run dev


### Backend tests
- Navigate to Backend.Tests folder
- dotnet test




## Design Decisions

- **TriviaStorageService abstraction**: The storage service uses an `IStorageProvider` interface. Currently, an in-memory provider (`InMemoryStorageProvider`) is used, but this could be swapped with a Redis or database-backed provider for scalability or persistence without changing the core service logic.  

- **API and State Management**: The frontend uses TanStack Query to fetch and cache trivia sessions, and mutations for submitting answers. This allows for automatic caching, invalidation, and a clean separation of concerns between UI and data fetching.  

- **Minimal front-end design**: I decided not go overboard with front-end design. I had plans to make a fully customizable Trivia builder (Question amount, type, difficulty etc...) however I don't think that adds value to this demonstration. A very minimal front-end was supplied instead with just a basic interface for N questions. (Defined in appSettings in the backend)

- **Component Design**: 
  - `TriviaBox` handles displaying questions and collecting user answers.  
  - `TriviaQuestion` handles displaying a single Question, highlitable buttons per option
  - `TriviaResultsDialog` shows the results, including the number of correct answers and the correct answers for wrong ones. 

- **Unit Tests**: Unit tests cover `TriviaService` and `TriviaStorageService` independently, using mocks to isolate dependencies, ensuring the logic works correctly without relying on calling any external api's (The Trivia API)

## Tech Stack

- **Frontend**: React + TypeScript, TanStack Query, ShadCN UI, Tanstack Start  
- **Backend**: .NET 10, C#, minimal API, xUnit & Moq for testing  
- **Storage**: Abstracted with an interface, currently in-memory cache, easily replaceable with persistent storage