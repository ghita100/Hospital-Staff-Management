<template>
  <v-dialog
    :model-value="showDialog"
    @update:model-value="$emit('update:showDialog', $event)"
    max-width="400"
  >
    <v-card>
      <v-card-title class="text-h5 text-error"> Sterge Doctor </v-card-title>

      <v-card-text>
        Esti sigur ca vrei sa stergi doctorul <strong>{{ doctor?.name }}</strong>?
        <br>
        Aceasta actiune este ireversibila.
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="grey" variant="text" @click="closeDialog">Anuleaza</v-btn>
        
        <v-btn color="red" variant="flat" @click="confirmDelete">Sterge</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import axios from "axios";

export default {
  name: "DeleteDoctor",

  props: {
    showDialog: Boolean,
    doctor: Object 
  },

  methods: {
    async confirmDelete() {
      if (!this.doctor || !this.doctor.id) {
        alert("Eroare: Nu pot gasi ID-ul doctorului. Da un refresh la pagina si incearca din nou.");
        return; 
      }

      try {
        await axios.delete(`http://localhost:8081/doctors/${this.doctor.id}`);
        
        this.$emit("doctor-deleted");
        this.closeDialog();
        
      } catch (error) {
        console.error("Eroare la stergerea doctorului:", error);
        
        if (error.response && error.response.status === 500) {
            alert("Nu se poate sterge acest doctor! Probabil are date asociate (pacienti/programari) în baza de date.");
        } else {
            alert("A aparut o eroare la stergere. Verifica consola.");
        }
      }
    },

    closeDialog() {
      this.$emit("update:showDialog", false);
    }
  }
};
</script>