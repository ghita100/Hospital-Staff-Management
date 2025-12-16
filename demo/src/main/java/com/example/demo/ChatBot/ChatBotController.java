package com.example.demo.ChatBot;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import java.util.Map;
@RestController
@RequestMapping("/chatbot")
@CrossOrigin
public class ChatBotController {
    @Autowired
    private ChatBotService chatbotService;

    @PostMapping
    public String chat(@RequestBody Map<String, String> body)
    {
        String request = body.get("question");
        return chatbotService.askOllama(request);
    }
}
