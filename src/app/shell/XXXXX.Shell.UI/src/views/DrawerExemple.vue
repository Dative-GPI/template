<template>
  <v-skeleton-loader v-if="loading" />
  <div v-else>
    <d-btn @click="openDrawer"> Open drawer </d-btn>
    <div v-for="exe in exemples" :key="exe.id"> {{ exe.label }}</div>

    <!-- See the comportement of high height drawer -->
      <d-btn @click="items = []"> Reset </d-btn>
      <div v-for="item in items" :key="item" class="text-h1">
        {{ item }}
      </div>
      <d-btn @click="growth"> Growth </d-btn>
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
import { JTDSchemaType } from "ajv/dist/jtd";
import { ExempleDetails, ExempleInfos } from "@/domain/models";
import { onCollectionChanged } from "@/tools";

@Component({
  components: {
    
  }
})
export default class DrawerExemple extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Inject(ORGANISATION)
  organisationId!: string;

  items: any[] = [];

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

  growth() {
    length = this.items.length;
    for(let i = length; i < length+10; i++) {
      this.items.push(i);
    }
  }
}
interface DrawerPayload {
  drawer: boolean;
  success?: boolean;
  path: string;
}
</script>