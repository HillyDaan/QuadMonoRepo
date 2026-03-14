import type { TriviaResponseDTO } from "#/types/dto/responses/TriviaResponseDTO";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";

const BASE_URL = "http://localhost:5136";

export function useTriviaSession() {
  return useQuery({
    queryKey: ['triviaSession'],
    queryFn: async () => {
      const response = await axios.get<TriviaResponseDTO>(`${BASE_URL}/questions`);    
      const data = response.data;
      console.log('Data =', data)
      return data;
    }
  })
}