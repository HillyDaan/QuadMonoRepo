import type { TriviaAnswersRequestDTO } from "#/types/dto/requests/TriviaAnswersRequestDTO";
import type { TriviaAnswersResponseDTO } from "#/types/dto/responses/TriviaAnswersResponseDTO";
import type { TriviaResponseDTO } from "#/types/dto/responses/TriviaResponseDTO";
import { useMutation, useQuery } from "@tanstack/react-query";
import axios from "axios";

const BASE_URL = import.meta.env.VITE_TRIVIA_BACKEND_API + '/questions' as string;

export function useTriviaSession() {
  return useQuery({
    queryKey: ['triviaSession'],
    queryFn: async () => {
      const response = await axios.get<TriviaResponseDTO>(`${BASE_URL}`);    
      return response.data;
    }
  })
}

export function useValidateTriviaAnswers() {
  return useMutation({
    mutationFn: async (data: TriviaAnswersRequestDTO) => {
      const response = await axios.post<TriviaAnswersResponseDTO>(
        `${BASE_URL}`,
        data
      );
      return response.data;
    }
  })
}