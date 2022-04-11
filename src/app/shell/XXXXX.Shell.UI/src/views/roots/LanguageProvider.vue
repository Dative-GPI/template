<template>
  <div v-if="!language">Loading languages</div>
  <div v-else>
    <slot />
  </div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  ProvideReactive,
  Prop,
  InjectReactive,
} from "vue-property-decorator";

import { ApplicationDetails, Language } from "@/domain/models";
import {
  APPLICATION,
  PROVIDER,
  LANGUAGE,
  SET_LANGUAGE,
} from "@/config";

@Component
export default class LanguageProvider extends Vue {
  @Prop({ required: false, default: () => null })
  userId!: string | null;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  @InjectReactive(APPLICATION)
  application!: ApplicationDetails | null;

  @ProvideReactive(LANGUAGE)
  language: Language | null = null;

  @ProvideReactive(SET_LANGUAGE)
  async setLanguage(language: Language): Promise<void> {
    // Set the language in the sessionStorage
    localStorage.setItem("language", JSON.stringify(language));

    // Reload
    this.$router.go(0);
  }

  mounted(): void {
    if (localStorage.getItem("language") != null) {
      this.language = JSON.parse(localStorage.getItem("language")!);
    } else if (this.application != null) {
      const app = this.application;
      this.language =
        this.application.languages.find(
          (l) => l.id === app.fallbackLanguageId
        ) || null;
    }

    if (this.language) {
      this.$emit("input", this.language.id);
    }
  }
}
</script>