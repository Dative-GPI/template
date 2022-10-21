<template>
  <translation-list :edit-mode="editMode" />
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import TranslationList from "../components/translations/TranslationList.vue";

@Component({
  components: {
    TranslationList,
  },
})
export default class Translations extends Vue {
  // Properties
  // Data
  // Computed Properties

  get editMode() {
    return this.$route.hash.includes("editMode=true");
  }

  // Methods
  // Lifecycle
}
</script>

<style scoped></style>
