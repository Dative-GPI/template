<template>
  <v-container class="pa-0 ma-0" fluid>
    <v-row no-gutters class="ma-0 pa-0">
      <d-btn v-if="pageInformation != null" icon class="d-page-information-open mr-3" @click="togglePageInformation">
        <v-icon :small="false" :color="pageInformation.open ? 'blue-1' : 'grey-3'">
          mdi-information-outline
        </v-icon>
      </d-btn>
      <v-breadcrumbs :items="extendedItems" v-bind="$attrs" v-on="$listeners" class="pa-0 ma-0">
        <template v-slot:item="{ item }">
          <v-breadcrumbs-item v-bind="item" class="text--blue-2">
            {{ item.text ? item.text : $tr(item.codeLabel, item.defaultLabel) }}
          </v-breadcrumbs-item>
        </template>
      </v-breadcrumbs>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Prop, InjectReactive, Inject } from "vue-property-decorator";

import { PAGE_INFORMATIONS, PROVIDER, SERVICES as S } from "@/config";
// import { PageInformation } from "@/domain/models";
// import { IPageInformationService } from "@/interfaces";

@Component({
  inheritAttrs: false,
})
export default class Breadcrumbs extends Vue {
  // @InjectReactive(PAGE_INFORMATIONS)
  // pageInformations!: PageInformation[];

  @Inject(PROVIDER)
  container!: DependencyContainer;
  
  @Prop({ required: true })
  items!: any[];

  @Prop({ required: true })
  code!: string;

  get extendedItems(): { codeLabel: string; defaultLabel: string }[] {
    return this.items.concat({
      codeLabel: "",
      defaultLabel: "",
    });
  }

  // togglePageInformation() {
  //   if (this.pageInformation.open) {
  //     this.pageInformationService.remove(this.pageInformation.id);
  //   }
  //   else {
  //     this.pageInformationService.create(this.code);
  //   }
  // }

  // get pageInformation() {
  //   return this.pageInformations.filter(pi => pi.code === this.code)[0];
  // }

  // get pageInformationService(): IPageInformationService {
  //   return this.container.resolve<IPageInformationService>(S.PAGEINFORMATIONSERVICE);
  // }
}
</script>