<template>
  <v-app>
    <v-app-bar color="primary" app>
      <v-app-bar-title>Aplicatie Spital</v-app-bar-title>
      <v-spacer></v-spacer>
      
      <v-btn text to="/">Acasa</v-btn>
      <v-btn text to="/doctors">Doctori</v-btn>
    </v-app-bar>

    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'App'
}
</script>