<template>
  <example-component />
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import ExampleComponent from "../components/example/ExampleComponent.vue";

@Component({
  components: {
    ExampleComponent,
  },
})
export default class Example extends Vue {
  // Properties
  // Data
  // Computed Properties
  // Methods
  // Lifecycle
}
</script>

<style scoped></style>
