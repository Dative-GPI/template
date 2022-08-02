<template>
  <div>
    <div class="text-h2">Page secrete shhhhhhhut</div>
  </div>
</template>

<script lang="ts">
import { EXEMPLES_PATH, PROVIDER, SERVICES as S } from "@/config";
import { IExtensionCommunicationService } from "@/interfaces";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

@Component({
  components: {}
})
export default class Secret extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  get editMode() {
    return this.$route.hash.includes("editMode=true");
  }

  // Data
  // Computed Properties

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      S.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  mounted() {
    this.extensionCommunicationService.setTitle("Secret");
    this.extensionCommunicationService.setCrumbs([
      {
        text: "Exemple",
        to: `${EXEMPLES_PATH}`,
        disabled: false
      },
      {
        text: "Secret",
        to:
          "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        disabled: true
      }
    ]);
  }
}
</script>

