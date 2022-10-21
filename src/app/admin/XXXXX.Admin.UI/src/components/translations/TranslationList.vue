<template>
  <d-data-list
    disable-tiles
    :columns-sortable="false"
    :items="translations"
    :columns.sync="headers"
    :loading="fetching"
    class="mt-3"
  >
    <template #header-action>
      <import-translations-btn v-if="editMode" />
    </template>

    <template #table-item.languages="{ item }">
      <languages-chip-set :value="getLanguages(item)" :editable="false" />
    </template>

    <template #table-item.organisationTypes="{ item }">
      <organisation-types-chip-set
        :value="getOrganisationTypes(item)"
        :editable="false"
      />
    </template>

    <template #table-item.actions="{ item }">
      <d-btn icon @click="edit(item)">
        <d-icon>mdi-pencil</d-icon>
      </d-btn>
    </template>
  </d-data-list>
</template>

<script lang="ts">
import _ from "lodash";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Prop, Vue, Watch } from "vue-property-decorator";

import { PROVIDER, SERVICES, UPDATE_TRANSLATION_DRAWER_PATH } from "@/config";
import {
  ApplicationTranslation,
  Language,
  Translation,
  TranslationRequest,
  translationRequestSchema,
  TranslationResponse,
  UpdateApplicationTranslation,
  UpdateTranslationsRequest,
  updateTranslationsRequestSchema,
} from "@/domain/models";
import {
  IApplicationLanguageService,
  IApplicationTranslationService,
  IExtensionCommunicationService,
  ITranslationService,
} from "@/interfaces";

import LanguagesChipSet from "./LanguagesChipSet.vue";
import OrganisationTypesChipSet from "./OrganisationTypesChipSet.vue";
import ImportTranslationsBtn from "./drawers/ImportTranslationsBtn.vue";

@Component({
  components: {
    LanguagesChipSet,
    OrganisationTypesChipSet,
    ImportTranslationsBtn
  },
})
export default class TranslationList extends Vue {
  // Properties

  @Prop({ required: true })
  editMode!: boolean;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  fetchingLanguages = true;
  fetchingTranslations = true;
  fetchingApplicationTranslations = true;
  updating = false;

  languages: Language[] = [];
  translations: Translation[] = [];
  applicationTranslations: ApplicationTranslation[] = [];

  // Computed Properties

  get fetching() {
    return (
      this.fetchingLanguages ||
      this.fetchingTranslations ||
      this.fetchingApplicationTranslations
    );
  }

  get applicationLanguageService() {
    return this.container.resolve<IApplicationLanguageService>(
      SERVICES.APPLICATIONLANGUAGESERVICE
    );
  }

  get applicationTranslationService() {
    return this.container.resolve<IApplicationTranslationService>(
      SERVICES.APPLICATIONTRANSLATIONSERVICE
    );
  }

  get translationService() {
    return this.container.resolve<ITranslationService>(
      SERVICES.TRANSLATIONSERVICE
    );
  }

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      SERVICES.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  get headers() {
    return [
      {
        text: this.$tr("ui.common.code", "Code"),
        value: "code",
        sortable: true,
      },
      {
        text: this.$tr("ui.admin.translations.languages", "Translations"),
        value: "languages",
      },
      {
        text: this.$tr(
          "ui.admin.translations.specifics",
          "Specific translations"
        ),
        value: "organisationTypes",
      },
      {
        text: this.$tr("ui.admin.translations.default", "Default translation"),
        value: "value",
      },
      ...(this.editMode
        ? [
            {
              text: this.$tr("ui.common.actions", "Actions"),
              value: "actions",
            },
          ]
        : []),
    ];
  }

  // Methods

  getLanguages(item: Translation) {
    return _(this.applicationTranslations)
      .filter(
        (at) => at.translationCode == item.code && at.organisationTypeId == null
      )
      .groupBy((tr) => tr.languageCode)
      .map((entry) => entry[0].languageCode)
      .value();
  }

  getOrganisationTypes(item: Translation) {
    return _(this.applicationTranslations)
      .filter(
        (at) => at.translationCode == item.code && at.organisationTypeId != null
      )
      .groupBy((tr) => tr.organisationTypeId)
      .map((entry) => entry[0].organisationTypeId)
      .value();
  }

  async edit(item: Translation) {
    await this.extensionCommunicationService.openDrawer(
      UPDATE_TRANSLATION_DRAWER_PATH(item.code)
    );
  }

  sendTranslations(request: TranslationRequest) {
    const translation = this.translations.find(
      (tr) => tr.code == request.translationCode
    );

    if (!translation)
      throw new Error(
        "Couldn't find translation for code " + request.translationCode
      );

    const response: TranslationResponse = {
      messageType: "translation-response",
      translation: translation,
      applicationTranslations: this.applicationTranslations.filter(
        (tr) => tr.translationCode == request.translationCode && !!tr.languageCode
      ),
    };

    this.extensionCommunicationService.notify(response);
  }

  updateTranslations(payload: UpdateTranslationsRequest) {
    let newTranslations = this.applicationTranslations.filter(
      (tr) => tr.translationCode != payload.translationCode
    );
    newTranslations.push(...payload.applicationTranslations);
    this.applicationTranslations = newTranslations;

    this.update();
  }

  async update() {
    this.updating = true;

    try {
      const payload: UpdateApplicationTranslation[] = this.applicationTranslations.map(
        (tr) => ({
          translationCode: tr.translationCode,
          languageCode: tr.languageCode,
          organisationTypeId: tr.organisationTypeId,
          value: tr.value,
        })
      );

      await this.applicationTranslationService.update(payload);
    } finally {
      this.updating = false;
    }
  }

  // Lifecycle

  mounted() {
    this.extensionCommunicationService.subscribe(
      translationRequestSchema,
      location.href,
      this.sendTranslations
    );

    this.extensionCommunicationService.subscribe(
      updateTranslationsRequestSchema,
      location.href,
      this.updateTranslations
    );

    this.applicationTranslationService.subscribe("reset", (ev) => {
      if (ev.action == "reset") {
        this.applicationTranslations = ev.items;
      }
    });

    this.fetchLanguages();
    this.fetchTranslations();
    this.fetchApplicationTranslations();
  }

  async fetchLanguages() {
    this.fetchingLanguages = true;

    try {
      this.languages = await this.applicationLanguageService.getMany();
    } finally {
      this.fetchingLanguages = false;
    }
  }

  async fetchTranslations() {
    this.fetchingTranslations = true;

    try {
      this.translations = await this.translationService.getMany();
    } finally {
      this.fetchingTranslations = false;
    }
  }

  async fetchApplicationTranslations() {
    this.fetchingApplicationTranslations = true;

    try {
      this.applicationTranslations = await this.applicationTranslationService.getMany();
    } finally {
      this.fetchingApplicationTranslations = false;
    }
  }

  @Watch("editMode")
  onEditModeChanged() {
    if (this.editMode == false) {
      this.update();
    }
  }
}
</script>

<style scoped></style>
