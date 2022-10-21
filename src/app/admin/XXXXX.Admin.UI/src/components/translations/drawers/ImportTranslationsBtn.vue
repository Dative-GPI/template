<template>
  <div class="ma-0 pa-0 ml-3">
    <d-btn-drawer @click="openDrawer" icon="mdi-download">
      {{ $tr("ui.admin.translations.import", "Import translations") }}
    </d-btn-drawer>
  </div>
</template>

<script lang="ts">
import { IMPORT_TRANSLATIONS_DRAWER_URL, PROVIDER, SERVICES } from "@/config";
import { IExtensionCommunicationService } from "@/interfaces";
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Prop, Inject } from "vue-property-decorator";

@Component({})
export default class ImportTranslationsBtn extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data
  // Computed Properties

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(SERVICES.EXTENSIONCOMMUNICATIONSERVICE);
  }

  // Methods

  openDrawer() {
    this.extensionCommunicationService.openDrawer(IMPORT_TRANSLATIONS_DRAWER_URL);
  }

  // Lifecycle
}
</script>
