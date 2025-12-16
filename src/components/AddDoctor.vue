<template>
  <v-dialog
    :model-value="showDialog"
    @update:model-value="$emit('update:showDialog', $event)"
    max-width="400"
  >
    <v-card>
      <v-card-title> Add Doctor </v-card-title>

      <v-card-text>
        <v-text-field 
          label="Name"
          v-model="form.name"
        />

        <v-text-field
          label="Specialization"
          v-model="form.specialization"
        />

        <v-select
          label="Department"
          :items="departments"
          item-title="name"
          item-value="id"
          v-model="form.departmentId"
        />
      </v-card-text>

      <v-card-actions>
        <v-btn color="green" @click="createDoctor">Create</v-btn>
        <v-btn color="red" @click="closeDialog">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import axios from "axios";

export default {
  name: "AddDoctor",

  props: {
    showDialog: Boolean
  },

  data() {
    return {
      doctors: [],
      departments: [],

      form: {
        name: "",
        specialization: "",
        departmentId: null,
      },
    };
  },

  async mounted() {
    try {
      const res = await axios.get("http://localhost:8081/departments");
      this.departments = res.data;
    } catch (error) {
      console.error("Error loading departments:", error);
    }
  },

  methods: {
    async createDoctor() {
      try {
        const payload = {
           name: this.form.name,
           specialization: this.form.specialization,
          department: {
               id: this.form.departmentId
           }
        };
        console.log("Ce trimitem la server:", payload);

        await axios.post("http://localhost:8081/doctors", payload);

        this.$emit("doctor-created");
        this.closeDialog();
      } catch (error) {
        console.error("Error creating doctor:", error);
      }
    },

    closeDialog() {
      this.$emit("update:showDialog", false);
      this.form = {
        name: "",
        specialization: "",
        departmentId: null
      };
    }
  }
}
</script>
