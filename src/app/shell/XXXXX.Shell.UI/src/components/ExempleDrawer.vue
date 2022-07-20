<template>
  <drawer :title="title" :width="width" :path="path" v-model="drawer">
    <template #default>

      <!-- How to change drawer width -->
      <d-btn @click="width = 500" right>Set width 500</d-btn>
      <d-btn @click="width = 300" right>Set width 300</d-btn>
      <d-text-field :editable="true" v-model="exemple" />

      <!-- See the comportement of high height drawer -->
      <d-btn @click="items = []"> Reset </d-btn>
      <div v-for="item in items" :key="item" class="text-h1">
        {{ item }}
      </div>
      <d-btn @click="growth"> Growth </d-btn>

    </template>
    <template #actions>
      <v-spacer />
      <d-btn @click="onSuccess" right>Create</d-btn>
    </template>
  </drawer>
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
import Drawer from "@/components/shared/Drawer.vue";

@Component({
  components: {
    Drawer
  }
})
export default class ExempleDrawer extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Inject(ORGANISATION)
  organisatioId!: string;

  items: any[] = [];

  title = "My Drawer";

  exemple = "exemple";

  width = 256;

  drawer = true;

  get path() {
    return EXEMPLES_DRAWER_PATH;
  }

  get exempleService() {
    return this.container.resolve<IExempleService>(S.EXEMPLESERVICE);
  }

  growth() {
    length = this.items.length;
    for(let i = length; i < length+10; i++) {
      this.items.push(i);
    }
  }

  onSuccess() {
    this.exempleService.create(this.organisatioId, { label: this.exemple });
    this.drawer = false;
  }
}
</script>