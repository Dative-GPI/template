<template>
  <div>
    <d-title class="mt-5 text-h5">{{
      $tr("ui.admin.translations.drawer.general-title", "General translations")
    }}</d-title>

    <language-translation-inputs v-bind="$attrs" v-on="$listeners" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import LanguageTranslationInputs from "./LanguageTranslationInputs.vue";

@Component({
  components: {
    LanguageTranslationInputs,
  },
})
export default class UpdateGeneralTranslations extends Vue {
  // Properties
  // Data
  // Computed Properties
  // Methods
  // Lifecycle
}
</script>

<style scoped></style>
