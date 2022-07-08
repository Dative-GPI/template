<template>
  <div name="drawer" style="height: 100vh" class="pa-3">
    <slot name="header">
      <v-row
        no-gutters
        align="start"
        justify="start"
        class="mb-3"
        style="flex-wrap: nowrap"
      >
        <d-btn icon @click="close(false)">
          <v-icon large>mdi-chevron-right</v-icon>
        </d-btn>
        <slot name="title-outer">
          <d-title class="ml-2">
            <slot name="title">{{ title }}</slot>
          </d-title>
        </slot>
      </v-row>
    </slot>

    <slot></slot>

    <v-footer absolute v-if="$scopedSlots['actions']" color="transparent">
      <slot name="actions"></slot>
    </v-footer>
  </div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue, Prop, Watch } from "vue-property-decorator";

import {
  PROVIDER,
  SERVICES as S
} from "@/config";
import { IExtensionCommunicationService } from "@/interfaces";

@Component({
  components: {}
})
export default class ExempleDrawer extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;
  
  @Prop({required: true})
  title!: string

  @Prop({required: true})
  value!: string

  @Prop({required: false, default: 256})
  width!: number

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      S.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  close(success: boolean) {
    this.extensionCommunicationService.closeDrawer(
      this.$route.path,
      success
    );
  }

  setWidth() {
    this.extensionCommunicationService.setWidth(this.width, this.$route.path);
  }

  @Watch("width")
  onWidthChanged(){
    this.setWidth();
  }

  @Watch("value")
  onValueChanged(){
    this.close(true);
  } 
}
</script>