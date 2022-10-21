<template>
  <drawer
    :width="601"
    :title="$tr('ui.admin.translations.import', 'Import translations')"
    v-model="drawer"
  >
    <div class="pa-4" v-if="translationSet.size">
      <div>
        {{
          $tr(
            "ui.admin.translations.import-details",
            "Please provide a csv file with the code as the first column"
          )
        }}
      </div>

      <d-text-field
        class="pt-4"
        v-model="separator"
        :label="$tr('ui.common.separator', 'Separator')"
      />

      <v-row no-gutters class="pt-4">
        <d-btn-file accept="text/csv" @input="csv = $event">{{
          $tr("ui.common.import-csv", "Import csv file")
        }}</d-btn-file>

        <d-btn-latch class="ml-5" @click="downloadTranslations">{{
          $tr("ui.common.download-csv", "Download csv file")
        }}</d-btn-latch>
      </v-row>

      <div v-for="(column, index) in columns" :key="column">
        <template
          v-if="
            index >= 1 &&
              languages.length > index &&
              organisationTypeIds.length > index
          "
        >
          <d-card class="mt-5">
            <div class="text-h6">
              {{ $tr("ui.common.column", "Column") }}
              {{ convertToLetter(index) }}
            </div>

            <select-application-language
              class="mt-4"
              v-model="languages[index]"
              :label="$tr('ui.common.language', 'Language')"
              clearable
            />

            <d-switch
              class="mt-2"
              :label="
                $tr('ui.common.specific-translation', 'Specific translation')
              "
              v-model="useOrganisationType[index]"
            >
            </d-switch>

            <select-organisation-type
              class="mt-4"
              v-if="useOrganisationType[index]"
              v-model="organisationTypeIds[index]"
              :label="$tr('ui.common.organisation-type', 'Organisation type')"
              clearable
            />
          </d-card>
        </template>
      </div>
    </div>

    <template #actions>
      <div v-if="csv">
        {{ ignoredTranslations }} / {{ totalTranslations }}
        {{ $tr("ui.common.ignored-translations", "translations ignored") }}
      </div>

      <v-spacer />

      <d-btn-cancel @click="cancel" class="mr-3">{{
        $tr("ui.common.cancel", "Cancel")
      }}</d-btn-cancel>

      <d-btn-save
        :disabled="!translations.length"
        :loading="saving"
        @click="save"
      >
        {{ $tr("ui.common.import", "Import") }}
      </d-btn-save>
    </template>
  </drawer>
</template>

<script lang="ts">
import _ from "lodash";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue, Watch } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";
import {
  IApplicationLanguageService,
  IApplicationTranslationService,
  IOrganisationTypeService,
  ITranslationService,
} from "@/interfaces";
import {
  buildTranslationCSVContent,
  convertColumnToLetter,
  decodeCSVFile,
  downloadCSVContent,
} from "@/tools";
import { Language, OrganisationTypeInfos } from "@/domain/models";

import SelectOrganisationType from "@/components/shared/selects/SelectOrganisationType.vue";
import SelectApplicationLanguage from "@/components/shared/selects/SelectApplicationLanguage.vue";

@Component({
  components: {
    SelectApplicationLanguage,
    SelectOrganisationType,
  },
})
export default class ImportTranslationsDrawer extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  get appLanguageService(): IApplicationLanguageService {
    return this.container.resolve<IApplicationLanguageService>(
      S.APPLICATIONLANGUAGESERVICE
    );
  }

  get organisationTypeService(): IOrganisationTypeService {
    return this.container.resolve<IOrganisationTypeService>(
      S.ORGANISATIONTYPESERVICE
    );
  }

  get applicationTranslationService(): IApplicationTranslationService {
    return this.container.resolve<IApplicationTranslationService>(
      S.APPLICATIONTRANSLATIONSERVICE
    );
  }

  get translationService(): ITranslationService {
    return this.container.resolve<ITranslationService>(S.TRANSLATIONSERVICE);
  }

  // Data

  drawer = true;
  saving = false;

  separator = ",";
  csv = "";
  translationSet: Set<string> = new Set<string>();

  languages: (string | null)[] = [];
  organisationTypeIds: (string | null)[] = [];
  useOrganisationType: boolean[] = [];

  // Computed Properties

  get csvContent(): string[][] {
    if (!this.csv || !this.separator) return [];
    return decodeCSVFile(this.csv, this.separator);
  }

  get columns() {
    return this.csvContent.reduce(
      (prev, current) => (current.length > prev ? current.length : prev),
      0
    );
  }

  get totalTranslations(): number {
    if (!this.csvContent) return 0;

    let count = 0;
    // Start at 1 to avoid headers
    for (let row of this.csvContent) {
      const code = row[0];
      if (!code || !this.translationSet.has(code)) {
        continue;
      }

      // Start at 1 to avoid code
      for (let colIndex = 1; colIndex < row.length; colIndex++) {
        if (!!row[colIndex]) {
          count++;
        }
      }
    }

    return count;
  }

  get translations() {
    const result = [];

    for (let row of this.csvContent) {
      const code = row[0];
      if (!code || !this.translationSet.has(code)) {
        continue;
      }

      // Start at 1 to avoid code
      for (let colIndex = 1; colIndex < row.length; colIndex++) {
        const languageCode = this.languages[colIndex];
        const useOrganisationType = this.useOrganisationType[colIndex];
        const organisationTypeId = this.organisationTypeIds[colIndex];
        const value = row[colIndex];

        if (languageCode && value) {
          result.push({
            languageCode: languageCode,
            organisationTypeId: useOrganisationType ? organisationTypeId : null,
            translationCode: code,
            value: value,
          });
        }
      }
    }

    return result;
  }

  get ignoredTranslations() {
    if (this.totalTranslations == 0) return 0;
    return (this.totalTranslations - this.translations.length);
  }

  // Methods

  convertToLetter = convertColumnToLetter;

  cancel() {
    this.drawer = false;
  }

  async save() {
    this.saving = true;

    try {
      await this.applicationTranslationService.update(this.translations);
      this.drawer = false;
    } finally {
      this.saving = false;
    }
  }

  async downloadTranslations() {
    let languages = await this.appLanguageService.getMany();
    let organisationTypes = await this.organisationTypeService.getMany();
    let appTranslations = await this.applicationTranslationService.getMany();
    let defaultTranslations = await this.translationService.getMany();

    const csvBody = buildTranslationCSVContent(
      defaultTranslations,
      appTranslations,
      languages,
      organisationTypes,
      this.separator
    );
    const csvHeaders = this.buildCSVHeaders(languages, organisationTypes);

    downloadCSVContent(csvHeaders + "\n" + csvBody);
  }

  buildCSVHeaders(
    languages: Language[],
    organisationTypes: OrganisationTypeInfos[]
  ) {
    let headers = this.$tr("ui.common.code", "Code") + this.separator;
    headers +=
      this.$tr("ui.common.default-value", "Default value") + this.separator;

    for (let language of languages) {
      headers +=
        language.code +
        " - " +
        this.$tr("ui.common.default", "Default") +
        this.separator;

      for (let orgType of organisationTypes) {
        headers += language.code + " - " + orgType.code + this.separator;
      }
    }

    return headers;
  }

  // Lifecycle

  mounted() {
    this.fetch();
  }

  async fetch() {
    const translations = await this.translationService.getMany();
    this.translationSet = new Set<string>(translations.map((t) => t.code)); // Using a set for performance reasons
  }

  @Watch("columns")
  onColumnsChanged() {
    this.languages = Array(this.columns).fill(null);
    this.organisationTypeIds = Array(this.columns).fill(null);
    this.useOrganisationType = Array(this.columns).fill(false);
  }
}
</script>
