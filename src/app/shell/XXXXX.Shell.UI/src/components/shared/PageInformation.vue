<template>
  <v-container
    fluid
    class="pa-0 ma-0 pi page-information--background"
    :class="pageInformation.open ? 'pi-expanded' : 'pi-closed'"
  >
    <v-container fluid class="ma-0 pa-2">
      <span> {{ pageInformation.content }} </span>
    </v-container>
    <d-btn class="pi-button blue-4 grey-3--text" @click="togglePageInformation">
      <d-icon left> mdi-close </d-icon>
      <span> {{ $tr('ui.common.close', 'Close') }} </span>
    </d-btn>
  </v-container>
</template>

<script lang="ts">
// import { DependencyContainer } from "tsyringe";
// import { Component, Vue, Prop, InjectReactive, Inject } from "vue-property-decorator";

// import { PAGE_INFORMATIONS, PROVIDER, SERVICES as S } from "@/config";
// import { PageInformation } from "@/domain/models";
// import { IPageInformationService } from "@/interfaces";

// @Component({})
// export default class PageInformationWrapper extends Vue {
//   @InjectReactive(PAGE_INFORMATIONS)
//   pageInformations!: PageInformation[];

//   @Inject(PROVIDER)
//   container!: DependencyContainer;
  
//   @Prop({ required: true })
//   code!: string;

//   togglePageInformation() {
//     if (this.pageInformation.open) {
//       this.pageInformationService.remove(this.pageInformation.id);
//     }
//     else {
//       this.pageInformationService.create(this.code);
//     }
//   }

//   get pageInformation() {
//     return this.pageInformations.filter(pi => pi.code === this.code)[0];
//   }

//   get pageInformationService() {
//     return this.container.resolve<IPageInformationService>(S.PAGEINFORMATIONSERVICE);
//   }
// }
</script>

<style scoped>
.pi {
  position: relative;
  transition: all 0.28s;
}

.pi-closed {
  height: 0;
  opacity: 0;
  min-height: 0;
}

.pi-expanded {
  opacity: 1;
  min-height: 100px;
}

.pi-button {
  position: absolute;
  bottom: 12px;
  right: 12px;
}
</style>
