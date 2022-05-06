<template>
  <div name="drawerExample">
      <d-text-field :editable="true" v-model="exemple" />
    <d-btn @click="close">Close</d-btn>
    <d-btn @click="onSuccess">Create new exemple</d-btn>
  </div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import { EXEMPLES_DRAWER_PATH, ORGANISATION, PROVIDER, SERVICES as S,  } from "@/config";
import { IExempleService, IExtensionCommunicationService } from "@/interfaces";

@Component({
  components: {
  }
})
export default class CreateRecipeDrawer extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Inject(ORGANISATION)
  organisatioId!: string; 

  exemple = "exemple";

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      S.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  get exempleService() {
    return this.container.resolve<IExempleService>(
      S.EXEMPLESERVICE
    );
  }

  onSuccess() {
    this.exempleService.create(this.organisatioId, {label:this.exemple})
    this.close(true);
  }

  close(success: boolean = false) {
    console.log("closeDrawer")
    this.extensionCommunicationService.closeDrawer(
      EXEMPLES_DRAWER_PATH,
      success
    );
  }
}
</script>