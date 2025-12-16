<template>
  <v-container>
    <h2 class="text-h5 mb-4">Lista Doctori</h2>

    <div class="d-flex mb-4">
      <v-btn 
        color="success" 
        class="mr-4" 
        prepend-icon="mdi-plus"
        @click="showAddDialog = true"
      >
        Add Doctor
      </v-btn>

      <v-btn 
        color="primary" 
        class="mr-4" 
        prepend-icon="mdi-refresh"
        @click="fetchDoctors"
      >
        Refresh / Reset
      </v-btn>

      <v-btn 
        color="info" 
        class="mr-4" 
        prepend-icon="mdi-sort-alphabetical-ascending"
        @click="sortDoctorsName"
      >
        Sortează A-Z
      </v-btn>
    </div>

    <AddDoctor
      :current-user="testUser"
      v-model:showDialog="showAddDialog"
      @doctor-created="fetchDoctors"
    />

    <DeleteDoctor
      v-model:showDialog="showDeleteDialog"
      :doctor="selectedDoctor"
      @doctor-deleted="fetchDoctors"
    />

    <v-data-table 
      :items="doctors"
      :headers="headers"
      class="elevation-1"
      no-data-text="Nu există date."
    >
    <!-- eslint-disable-next-line vue/valid-v-slot -->
      <template v-slot:item.actions="{ item }">
        <v-btn 
          icon="mdi-delete" 
          size="small" 
          color="error" 
          variant="text"
          @click="openDeleteDialog(item)"
        />
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
import axios from "axios";
import AddDoctor from "./AddDoctor.vue"; 
import DeleteDoctor from "./DeleteDoctor.vue"; 

export default {
  name: "DoctorsView",
  components: {
    AddDoctor,
    DeleteDoctor 
  },
  data() {
    return {
      showAddDialog: false,    
      showDeleteDialog: false, 
      selectedDoctor: null,    
      
      doctors: [],
      
      testUser: {
        id: 1,
        department: { id: 2, name: "Cardiology" },
      },

      headers: [
        { title: "ID", key: "id" },            
        { title: "Nume", key: "name" },
        { title: "Specializare", key: "specialization" },
        { title: "Actiuni", key: "actions", sortable: false },
      ],
    };
  },

  methods: {
    async fetchDoctors() {
      try {
        const response = await axios.get("http://localhost:8081/doctors");
        this.doctors = response.data;
      } catch (error) {
        console.error("Error fetching doctors:", error);
      }
    },

    sortDoctorsName() {
      this.doctors.sort((a, b) => {
        const nameA = a.name ? a.name.toLowerCase() : "";
        const nameB = b.name ? b.name.toLowerCase() : "";
        
        return nameA.localeCompare(nameB);
      });
    },

    openDeleteDialog(item) {
      const doctorReal = item.raw || item;
      this.selectedDoctor = doctorReal; 
      this.showDeleteDialog = true; 
    }
  },

  mounted() {
    this.fetchDoctors();
  },
};
</script>