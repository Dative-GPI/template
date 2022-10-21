<template>
  <d-chip-set :value="items" :editable="false"></d-chip-set>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Prop, Vue } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";
import { IApplicationLanguageService } from "@/interfaces";
import { Language } from "@/domain/models";

import { onCollectionChanged } from "@/tools";

@Component({})
export default class LanguagesChipSet extends Vue {
  // Properties

  @Prop({ required: false, default: () => [] })
  value!: string[];

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  loading = false;
  appLanguages: Language[] = [];
  search = "";

  // Computed Properties

  get applicationLanguageService(): IApplicationLanguageService {
    return this.container.resolve<IApplicationLanguageService>(
      S.APPLICATIONLANGUAGESERVICE
    );
  }

  get items() {
    if (!this.value) return [];

    return this.appLanguages
      .filter((a) => this.value.includes(a.id))
      .map((a) => a.code)
      .sort();
  }

  // Methods
  // Lifecycle

  mounted() {
    this.fetch();
  }

  async fetch(): Promise<void> {
    this.loading = true;

    try {
      this.appLanguages = await this.applicationLanguageService.getMany();
    } finally {
      this.loading = false;
    }
  }
}
</script>
