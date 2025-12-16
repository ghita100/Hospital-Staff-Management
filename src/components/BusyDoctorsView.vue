<template>
  <v-container>
    <div class="d-flex align-center mb-4">
      <v-btn 
        icon="mdi-arrow-left" 
        variant="text" 
        to="/" 
        class="mr-2"
      ></v-btn>
      <h1 class="text-h4 text-primary">Doctori Ocupați</h1>
    </div>

    <v-data-table
      :items="busyDoctors"
      :headers="headers"
      class="elevation-1"
      no-data-text="Nu exista doctori cu ture active momentan."
    >
    <!-- eslint-disable-next-line vue/valid-v-slot -->
     <template #item.shifts="{ item }">
        <div v-for="shift in (item.raw ? item.raw.shifts : item.shifts)" :key="shift.id">
          
          <v-chip 
            color="grey-lighten-4" 
            variant="flat"
            class="ma-1 text-black text-body-2" 
            style="font-weight: 400;"
          >
            Shift {{ shift.id }}: {{ formatDate(shift.date) }}
          </v-chip>

        </div>
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
import axios from "axios";

export default {
  name: "BusyDoctorsView",
  
  data() {
    return {
      busyDoctors: [], 
      
      headers: [
        { title: "ID", key: "id" },
        { title: "Nume", key: "name" },
        { title: "Specializare", key: "specialization" },
        { title: "Program / Ture", key: "shifts" } 
      ]
    };
  },

  mounted() {
    this.fetchBusyDoctors();
  },

  methods: {
    async fetchBusyDoctors() {
      try {
        const response = await axios.get("http://localhost:8081/doctors/busy");
        this.busyDoctors = response.data;
      } catch (error) {
        console.error("Eroare la conexiunea cu serverul:", error);
      }
    },

    formatDate(dateString) {
      if (!dateString) return "";
      const date = new Date(dateString);
      return date.toLocaleDateString("ro-RO");
    }
  }
}
</script>