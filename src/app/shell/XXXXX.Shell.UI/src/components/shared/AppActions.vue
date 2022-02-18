<template>
  <v-row no-gutters>
    <v-btn icon @click="$emit('show:notifications')">
      <v-icon>mdi-bell-outline</v-icon>
    </v-btn>
    <v-btn icon @click="$emit('show:user')">
      <v-icon>mdi-account-circle</v-icon>
    </v-btn>
    <v-btn icon @click="$emit('show:settings')">
      <v-icon>mdi-settings</v-icon>
    </v-btn>
  </v-row>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({})
export default class AppActions extends Vue {}
</script>
