<template>
  <v-container class="text-center mt-5 d-flex flex-column" style="min-height: 80vh;">
    
    <div class="flex-grow-1 d-flex flex-column justify-center align-center">
      <h1 class="text-h3 text-primary mb-6">Bine ai venit!</h1>
      
      <div class="d-flex flex-column align-center ga-4">
        <v-btn color="secondary" size="large" to="/doctors" style="width: 300px;">
          Mergi la Lista de Doctori
        </v-btn>

        <v-btn color="secondary" size="large" to="/busy-doctors" style="width: 300px;">
          Vezi Doctorii Ocupati
        </v-btn>
        <v-btn color="primary" size="large" @click="showChatbot = true">
  Intreaba ChatBot-ul
</v-btn>
      </div>
    </div>
 <ChatBot v-model="showChatbot" />
    <div class="mt-10 border-t pt-4 text-grey-darken-2">
      <h3 class="text-h6 font-weight-bold mb-2">Spitalul Județean "Sănătatea"</h3>
      
      <div class="d-flex justify-center align-center ga-6 flex-wrap">
        
        <div class="d-flex align-center">
          <v-icon icon="mdi-email" color="primary" class="mr-2"></v-icon>
          <span>contact@spital-exemplu.ro</span>
        </div>

        <div class="d-flex align-center">
          <v-icon icon="mdi-phone" color="primary" class="mr-2"></v-icon>
          <span>021 123 45 67</span>
        </div>

        <div class="d-flex align-center">
          <v-icon icon="mdi-map-marker" color="primary" class="mr-2"></v-icon>
          <span>Str. Florilor Nr. 10</span>
        </div>

      </div>
      
      <p class="text-caption mt-2 text-grey">© 2025 Toate drepturile rezervate.</p>
    </div>
    
  </v-container>
</template>

<script>
import ChatBot from '../components/ChatBot.vue'

export default {
  name: "HomeView",
  components: { ChatBot },
  data() {
    return {
      showChatbot: false
    };
  }
}
</script>