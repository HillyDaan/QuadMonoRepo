# Quad Solutions Assesment

## Building the application
### Frontend
- (Make sure you have > Node 20)
- Navigate to Frontend folder
- Install dependencies: npm i
- Run dev server: npm run dev


### Backend
- (Make sure you have .NET 10)
- Navigate to Backend folder
- dotnet run

### Backend tests
- Navigate to Backend.Tests folder
- dotnet test


## Design Decisions

- **TriviaStorageService abstraction**: The storage service uses an `IStorageProvider` interface. Currently, an in-memory provider (`InMemoryStorageProvider`) is used, but this could be swapped with a Redis or database-backed provider for scalability or persistence without changing the core service logic.  

- **API and State Management**: The frontend uses TanStack Query to fetch and cache trivia sessions, and mutations for submitting answers. This allows for automatic caching, invalidation, and a clean separation of concerns between UI and data fetching.  

- **Component Design**: 
  - `TriviaBox` handles displaying questions and collecting user answers.  
  - `TriviaResultsDialog` shows the results, including the number of correct answers and the correct answers for wrong ones. 

- **Unit Tests**: Unit tests cover `TriviaService` and `TriviaStorageService` independently, using mocks to isolate dependencies, ensuring the logic works correctly without relying on external APIs.

## Tech Stack

- **Frontend**: React + TypeScript, TanStack Query, ShadCN UI, Tanstack Start  
- **Backend**: .NET 10, C#, minimal API, xUnit & Moq for testing  
- **Storage**: Abstracted with an interface, currently in-memory cache, easily replaceable with persistent storage