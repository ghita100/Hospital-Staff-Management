<template>
  <v-dialog v-model="internalDialog" max-width="400px">
    <v-card>
      <v-card-title>ChatBot</v-card-title>
      <v-card-text>
        <v-textarea
          label="ChatBot answer"
          v-model="chatResponse"
          readonly
        ></v-textarea>
        <v-text-field
          label="Your question"
          v-model="question"
        ></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" @click="send">Send</v-btn>
        <v-btn text @click="internalDialog = false">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import axios from "axios";

export default {
  name: "ChatBot",
  props: {
    modelValue: {  
      type: Boolean,
      required: true
    }
  },
  emits: ["update:modelValue"],
  data() {
    return {
       internalDialog: false,
    question: "",
    chatResponse: ""
    };
  },
  watch: {
    modelValue(newVal) {
      this.internalDialog = newVal; 
    },
    internalDialog(newVal) {
      this.$emit("update:modelValue", newVal); 
    }
  },
  methods: {
    async send() {
      if (!this.question) return;
      try {
        const response = await axios.post(
          "http://localhost:8081/chatbot",
          { question: this.question },
          { headers: { "Content-Type": "application/json" } }
        );
        this.chatResponse = response.data;
      } catch (error) {
        console.error("Error sending to chatbot:", error);
        this.chatResponse = "Error: could not get response";
      }
    }
  }
};
</script>


<style scoped>
.dialogClass {
  padding: 20px;
  background-color: white;
}
</style>