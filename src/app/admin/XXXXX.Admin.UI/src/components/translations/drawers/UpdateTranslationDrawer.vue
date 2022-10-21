<template>
  <drawer
    :width="601"
    :title="$tr('ui.admin.translations.update', 'Update Translation')"
    v-model="drawer"
  >
    <v-skeleton-loader
      type="article"
      v-if="!translation || !applicationTranslations"
    />
    <template v-else>
      <d-grid :items="items" class="mt-5">
        <template #item-value.code>
          {{ translation.code }}
        </template>
        <template #item-value.default>
          {{ translation.value }}
        </template>
      </d-grid>

      <update-general-translations
        v-model="generalTranslations"
        :code="translationCode"
      />

      <update-specific-translations
        :specific-translations.sync="specificTranslations"
        :selectedOrganisationTypeIds.sync="selectedOrganisationTypeIds"
        :translation-code="translationCode"
      />
    </template>

    <template #actions>
      <v-spacer />

      <d-btn-cancel @click="drawer = false" :loading="updating">{{
        $tr("ui.common.cancel", "Cancel")
      }}</d-btn-cancel>

      <d-btn-save class="ml-3" @click="updateTranslations" :loading="updating">{{
        $tr("ui.common.save", "Save")
      }}</d-btn-save>
    </template>
  </drawer>
</template>

<script lang="ts">
import { PROVIDER, SERVICES } from "@/config";
import { ApplicationTranslation, Translation, TranslationRequest, TranslationResponse, translationResponseSchema, UpdateTranslationsRequest } from "@/domain/models";
import { IExtensionCommunicationService } from "@/interfaces";
import _ from "lodash";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue, Watch } from "vue-property-decorator";
import UpdateGeneralTranslations from "./UpdateGeneralTranslations.vue";
import UpdateSpecificTranslations from "./UpdateSpecificTranslations.vue";

@Component({
  components: {
    UpdateGeneralTranslations,
    UpdateSpecificTranslations,
  },
})
export default class UpdateTranslationDrawer extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  drawer = true;
  updating = false;

  translation: Translation | null = null;
  applicationTranslations: ApplicationTranslation[] | null = null;

  generalTranslations: ApplicationTranslation[] = [];
  specificTranslations: { [orgTypeId: string]: ApplicationTranslation[] } = {};
  selectedOrganisationTypeIds: string[] = [];

  items = [
    {
      key: this.$tr("ui.admin.translation.code", "Code"),
      code: "code",
    },
    {
      key: this.$tr("ui.admin.translation.default", "Default value"),
      code: "default",
    },
  ];

  // Computed Properties

  get translationCode() {
    return this.$route.params.translationCode;
  }

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      SERVICES.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  // Methods

  updateTranslations() {
    this.updating = true;

    try {
      const allTranslations = [...this.generalTranslations];

      for (const id of this.selectedOrganisationTypeIds) {
        allTranslations.push(...[...(this.specificTranslations[id] ?? [])]); // Faster than concat
      }

      const updateMessage: UpdateTranslationsRequest = {
        messageType: "update-translation-request",
        translationCode: this.translationCode,
        applicationTranslations: allTranslations
      };
      this.extensionCommunicationService.notify(updateMessage);
      this.drawer = false;
    } finally {
      this.updating = false;
    }
  }

  initTranslations(response: TranslationResponse) {
    this.generalTranslations = response.applicationTranslations.filter(
      (tr) => tr.organisationTypeId == null
    );

    for (const translation of response.applicationTranslations) {
      const orgTypeId = translation.organisationTypeId;

      if (orgTypeId == null) continue;
      if (!this.specificTranslations[orgTypeId])
        this.specificTranslations[orgTypeId] = [];

      this.specificTranslations[orgTypeId].push(translation);
    }

    this.selectedOrganisationTypeIds = Object.keys(this.specificTranslations);

    this.translation = response.translation;
    this.applicationTranslations = response.applicationTranslations;
  }

  // Lifecycle

  mounted() {
    this.extensionCommunicationService.subscribe(
      translationResponseSchema,
      location.href,
      this.initTranslations
    );

    const request: TranslationRequest = {
      messageType: "translation-request",
      translationCode: this.translationCode,
    };
    this.extensionCommunicationService.notify(request);
  }
}
</script>

<style scoped></style>
