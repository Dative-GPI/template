<template>
  <v-skeleton-loader v-if="loading" />
  <div v-else>
    <d-btn @click="openDrawer"> Open drawer </d-btn>
    <div v-for="exe in exemples" :key="exe.id"> {{ exe.label }}</div>
  </div>
</template>


<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import {
  EXEMPLES_DRAWER_PATH,
  ORGANISATION,
  PROVIDER,
  SERVICES as S
} from "@/config";
import { IExempleService, IExtensionCommunicationService } from "@/interfaces";
import Drawer from "@/components/drawer.vue";
import { JTDSchemaType } from "ajv/dist/jtd";
import { ExempleDetails, ExempleInfos } from "@/domain/models";
import { onCollectionChanged } from "@/tools";

@Component({
  components: {
    Drawer
  }
})
export default class DrawerExemple extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Inject(ORGANISATION)
  organisationId!: string;

  drawerSchema: JTDSchemaType<DrawerPayload> = {
    properties: {
      drawer: { type: "boolean" },
      path: { type: "string" }
    },
    optionalProperties: {
      success: { type: "boolean" }
    }
  };

  loading = false;

  exemples: ExempleInfos[] = [];

  subscriberIds: number[] = [];

  get exempleService() {
    return this.container.resolve<IExempleService>(S.EXEMPLESERVICE);
  }

  mounted() {
    this.extensionCommunicationService.setTitle("Drawer exemple");
    this.exempleService.subscribe(
      "all",
      onCollectionChanged<ExempleInfos, ExempleDetails>(() => this.exemples)
    );
    this.fetch();
  }

  async fetch() {
    this.loading = true;
    try {
      this.exemples = await this.exempleService.getMany(this.organisationId);
    } finally {
      this.loading = false;
    }
  }

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      S.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  openDrawer() {
    this.extensionCommunicationService.openDrawer(EXEMPLES_DRAWER_PATH);
  }
}
interface DrawerPayload {
  drawer: boolean;
  success?: boolean;
  path: string;
}
</script>