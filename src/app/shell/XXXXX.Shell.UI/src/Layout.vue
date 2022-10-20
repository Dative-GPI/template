<template>
  <router-view name="default" :key="$route.fullPath"> </router-view>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";


@Component({})
export default class Layout extends Vue {
  // Properties
  // Data
  // Computed Properties
  // Methods
  // Lifecycle
}
</script>