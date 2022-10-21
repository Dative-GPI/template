<template>
  <d-select
    v-bind="$attrs"
    v-on="$listeners"
    :items="languages"
    :loading="loading"
    item-text="label"
    item-value="code"
  />
</template>


<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Prop, Vue } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";
import { IApplicationLanguageService } from "@/interfaces";
import { Language } from "@/domain/models";

@Component({})
export default class SelectApplicationLanguage extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  loading = false;
  languages: Language[] = [];

  // Computed Properties

  get applicationLanguageService(): IApplicationLanguageService {
    return this.container.resolve<IApplicationLanguageService>(S.APPLICATIONLANGUAGESERVICE);
  }

  // Methods

  mounted() {
    this.fetch();
  }

  async fetch(): Promise<void> {
    this.loading = true;
    try {
      this.languages = await this.applicationLanguageService.getMany();
    } finally {
      this.loading = false;
    }
  }
}
</script>
