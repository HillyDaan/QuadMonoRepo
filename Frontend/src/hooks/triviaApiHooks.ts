import type { TriviaAnswersRequestDTO } from "#/types/dto/requests/TriviaAnswersRequestDTO";
import type { TriviaAnswersResponseDTO } from "#/types/dto/responses/TriviaAnswersResponseDTO";
import type { TriviaResponseDTO } from "#/types/dto/responses/TriviaResponseDTO";
import { useMutation, useQuery } from "@tanstack/react-query";
import axios from "axios";

const BASE_URL = import.meta.env.VITE_TRIVIA_BACKEND_API as string;

export function useTriviaSession() {
  return useQuery({
    queryKey: ['triviaSession'],
    queryFn: async () => {
      console.log('sending to', `${BASE_URL}/questions`)
      const response = await axios.get<TriviaResponseDTO>(`${BASE_URL}/questions`);    
      return response.data;
    }
  })
}

export function useValidateTriviaAnswers() {
  return useMutation({
    mutationFn: async (data: TriviaAnswersRequestDTO) => {
      const response = await axios.post<TriviaAnswersResponseDTO>(
        `${BASE_URL}/checkanswers`,
        data
      );
      return response.data;
    }
  })
}