<template>
  <v-skeleton-loader type="paragraph" v-if="fetching" />
  <div v-else>
    <d-textarea
      class="mt-3 px-3"
      v-for="l in languages"
      :value="getValue(l.code)"
      @input="setValue(l.code, $event)"
      :key="code + '-' + organisationTypeId + '-' + l.code"
      :label="l.label"
    />
  </div>
</template>

<script lang="ts">
import { PROVIDER, SERVICES as S } from "@/config";
import { ApplicationTranslation, Language } from "@/domain/models";
import { IApplicationLanguageService } from "@/interfaces";
import { DependencyContainer } from "tsyringe";
import { Vue, Component, Inject, Prop } from "vue-property-decorator";

@Component({})
export default class LanguageTranslationInputs extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Prop({ required: true })
  value!: ApplicationTranslation[];

  @Prop({ required: true })
  code!: string;

  @Prop({ required: false, default: () => null })
  organisationTypeId!: string | null;

  // Data

  fetching = true;

  languages: Language[] = [];

  // Computed Properties

  get languageService(): IApplicationLanguageService {
    return this.container.resolve<IApplicationLanguageService>(
      S.APPLICATIONLANGUAGESERVICE
    );
  }

  // Methods

  getValue(languageCode: string) {
    const translation = this.value.find(
      (t) =>
        t.languageCode == languageCode &&
        t.organisationTypeId == this.organisationTypeId &&
        t.translationCode == this.code
    );

    if (translation) return translation.value;
    else return "";
  }

  setValue(languageCode: string, ev: string) {
    let newTranslations = this.value.slice();

    let index = newTranslations.findIndex(
      (t) =>
        t.languageCode == languageCode &&
        t.organisationTypeId == this.organisationTypeId
    );

    if (!ev || ev.length == 0) {
      if (index != -1) newTranslations.splice(index, 1);
    } else if (index != -1) {
      newTranslations[index].value = ev;
    } else {
      newTranslations.push({
        languageCode: languageCode,
        organisationTypeId: this.organisationTypeId,
        translationCode: this.code,
        value: ev,
      });
    }

    this.$emit("input", newTranslations);
  }

  // Lifecycle

  mounted() {
    this.fetch();
  }

  async fetch() {
    this.fetching = true;

    try {
      this.languages = await this.languageService.getMany();
    } finally {
      this.fetching = false;
    }
  }
}
</script>
