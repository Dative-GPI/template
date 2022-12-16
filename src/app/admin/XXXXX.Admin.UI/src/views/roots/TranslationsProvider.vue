<template>
  <div v-if="fetching"></div>
  <div v-else><slot></slot></div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  Watch,
  Prop,
  InjectReactive,
} from "vue-property-decorator";

import { ORGANISATION, PROVIDER, SERVICES as S } from "@/config";
import { IApplicationTranslationService } from "@/interfaces";

@Component({})
export default class TranslationsProvider extends Vue {
  // Properties

  @Prop({ required: true })
  languageCode!: string;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  fetching = true;

  // Computed Properties

  get applicationTranslationService(): IApplicationTranslationService {
    return this.container.resolve<IApplicationTranslationService>(
      S.APPLICATIONTRANSLATIONSERVICE
    );
  }

  // Methods
  // Lifecycle

  mounted(): void {
    this.applicationTranslationService.subscribe("update", (ev) => {
      if (ev.action == "update") {
        this.fetchTranslations();
      }
    });

    this.fetch();
  }

  async fetch(): Promise<void> {
    this.fetching = true;

    try {
      await this.fetchTranslations();
    } finally {
      this.fetching = false;
    }
  }

  async fetchTranslations(): Promise<void> {
    const translations = await this.applicationTranslationService.getCurrent();
    if (translations != null) this.$tm.set(translations);
  }

  @Watch("languageCode")
  onLanguageCodeChanged = this.fetch;
}
</script>
