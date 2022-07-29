<template>
  <v-skeleton-loader v-if="loading" />
  <div v-else>
    <d-btn @click="goto"> Go to drawer exemple </d-btn>
  </div>
</template>


<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import {
  EXEMPLES_PATH,
  GOTO_PATH,
  ORGANISATION,
  PROVIDER,
  SERVICES as S,
} from "@/config";
import { IExtensionCommunicationService } from "@/interfaces";

@Component({
  components: {
  }
})
export default class GoToExemple extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Inject(ORGANISATION)
  organisationId!: string;

  loading = false;
  
  goto(){
    this.$router.push({path:EXEMPLES_PATH});
  }

  mounted() {
    this.extensionCommunicationService.setTitle("Go to exemple");
    this.extensionCommunicationService.setCrumbs([
      {
        codeLabel: "goto",
        to: GOTO_PATH,
        defaultLabel: "Goto",
        disabled: false
      },
    ]);
    this.fetch();
  }

  async fetch() {
  }

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      S.EXTENSIONCOMMUNICATIONSERVICE
    );
  }
}
</script>