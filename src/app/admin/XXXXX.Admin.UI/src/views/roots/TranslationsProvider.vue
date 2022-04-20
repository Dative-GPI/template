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
  Prop,
} from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";

@Component
export default class TranslationsProvider extends Vue {
  @Prop({ required: false, default: () => null })
  languageId!: string | null;
  
  @Prop({ required: false, default: () => null })
  languageCode!: string | null;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // get translationService(): IApplicationTranslationService {
  //   return this.container.resolve<IApplicationTranslationService>(
  //     S.APPLICATIONTRANSLATIONSERVICE
  //   );
  // }

  fetching = true;

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {
    if (!this.languageId || !this.languageCode) return;

    this.fetching = true;

    try {
      // const translations = await this.translationService.getMany({
      // });
      // this.$tm.set(translations);
    } finally {
      this.fetching = false;
    }
  }

  @Watch("languageId")
  onLanguageChanged = this.fetch;
}
</script>