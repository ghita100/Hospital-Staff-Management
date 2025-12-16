package com.example.demo.ChatBot;
import com.example.demo.Doctor;
import com.example.demo.DoctorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;

import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;
@Service
public class ChatBotService {

    private final WebClient client;
    private final String ollamaModel = "gemma3:1b";


    private DoctorService doctorService;

    @Autowired
    public ChatBotService(DoctorService doctorService) {
        this.doctorService = doctorService;
        this.client = WebClient.builder()
                .baseUrl("http://localhost:11434")
                .defaultHeader(HttpHeaders.CONTENT_TYPE, MediaType.APPLICATION_JSON_VALUE)
                .build();
    }


    public String askOllama(String prompt) {
        String data = doctorService.getallDoctors().stream()
                .map(Doctor::toString)
                .collect(Collectors.joining(","));

        Map<String, Object> request = Map.of(
                "model", ollamaModel,
                "messages", List.of(
                        Map.of("role", "user", "content",
                                "You are a strict doctor database assistant.\n" +
                                        "You must answer ONLY using the doctor database provided below.\n" +
                                        "If the answer cannot be found exactly in the database, respond ONLY with: <<I cannot answer>>.\n\n" +

                                        "=== DOCTOR DATABASE (JSON) ===\n" +
                                        data + "\n" +
                                        "=== END DATABASE ===\n\n" +

                                        "Rules:\n" +
                                        "1. Do NOT invent any doctor name, specialization, department, or detail.\n" +
                                        "2. If the user asks something outside this database, answer <<I cannot answer>>.\n" +
                                        "3. If the question matches multiple doctors, return all of them.\n" +
                                        "4. Keep answers short and factual.\n\n" +

                                        "User question:\n" +
                                        prompt
                        )
                ),
                "stream", false
        );
        try {
            OllamaChatResponse result = client.post()
                    .uri("/api/chat")
                    .bodyValue(request)
                    .retrieve()
                    .bodyToMono(OllamaChatResponse.class)
                    .block();

            return result.message.content;

        } catch (Exception e) {
            e.printStackTrace();
            return "Error while contacting Ollama: " + e.getMessage();
        }
    }
}
    class OllamaChatResponse {
        public String model;
        public String created_at;
        public Message message;

        public static class Message {
            public String role;
            public String content;
        }
    }
