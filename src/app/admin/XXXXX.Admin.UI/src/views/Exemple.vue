<template>
  <div>
    <div class="text-h2">Bonjour je suis une page.</div>
    <div class="text-h7">L'edit mode est à {{ editMode }}</div>
    <exemple-component />
  </div>
</template>

<script lang="ts">
import { PROVIDER, SERVICES as S } from "@/config";
import { IExtensionCommunicationService } from "@/interfaces";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import ExempleComponent from "@/components/Exemple/ExempleComponent.vue";

@Component({
  components: {
    ExempleComponent
  }
})
export default class Exemple extends Vue {
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
    this.extensionCommunicationService.setTitle("Exemple");
    this.extensionCommunicationService.setCrumbs([
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Secret",
        to: "/applications/secret/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba/da3b3f44-d3b8-41e4-b89b-0e5dbedf1dba",
        defaultLabel: "Secret",
        disabled: false
      },
      {
        codeLabel: "Exemple",
        to: "Exemple",
        defaultLabel: "Exemple",
        disabled: true
      },
    ]);
  }
}
</script>

