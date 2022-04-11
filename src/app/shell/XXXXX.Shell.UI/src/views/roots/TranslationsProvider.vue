<template>
  <div v-if="fetching">Loading translations</div>
  <div v-else><slot></slot></div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  InjectReactive,
  Watch,
} from "vue-property-decorator";

import { ApplicationDetails, Language } from "@/domain/models";
import { APPLICATION, PROVIDER, SERVICES as S, LANGUAGE } from "@/config";
import { IApplicationTranslationService } from "@/interfaces";

@Component
export default class TranslationsProvider extends Vue {
  @InjectReactive(APPLICATION)
  application!: ApplicationDetails | null;

  @InjectReactive(LANGUAGE)
  language!: Language | null;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  get translationService(): IApplicationTranslationService {
    return this.container.resolve<IApplicationTranslationService>(
      S.APPLICATIONTRANSLATIONSERVICE
    );
  }

  fetching = true;

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {
    if (!this.language) return;

    this.fetching = true;

    try {
      // const translations = await this.translationService.getMany({
      //   languageId: this.language.id,
      // });
      // this.$tm.set(translations);
    } finally {
      this.fetching = false;
    }
  }

  @Watch("language")
  onLanguageChanged = this.fetch;
}
</script>