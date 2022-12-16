<template>
  <div class="update-specific-translations">
    <d-title class="mt-5 text-h5">{{
      $tr(
        "ui.admin.translations.drawer.specific-title",
        "Specific translations"
      )
    }}</d-title>

    <d-sub-title>{{
      $tr(
        "ui.admin.translations.drawer.specific-description",
        "Please select the organisation types that will have custom translations"
      )
    }}</d-sub-title>

    <v-skeleton-loader type="article" v-if="fetching" />
    <template v-else>
      <div>
        <v-row
          no-gutters
          class="my-3"
          v-for="organisationType in organisationTypes"
          :key="'select-' + organisationType.id"
        >
          <d-simple-checkbox
            :value="selectedOrganisationTypeIds.includes(organisationType.id)"
            @click="toggleOrganisationType(organisationType)"
          />
          <span class="ml-3">
            {{ organisationType.label }}
          </span>
        </v-row>
      </div>

      <div v-for="orgType in selectedOrganisationTypes" :key="orgType.id">
        <d-title class="mt-5 mb-3 text-h6">{{ orgType.label }}</d-title>
        <language-translation-inputs
          :value="getTranslations(orgType.id)"
          :code="translationCode"
          :organisationTypeId="orgType.id"
          @input="setTranslations(orgType.id, $event)"
        />
      </div>
    </template>
  </div>
</template>

<script lang="ts">
import { PROVIDER, SERVICES } from "@/config";
import { ApplicationTranslation, OrganisationTypeInfos } from "@/domain/models";
import { IOrganisationTypeService } from "@/interfaces";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Prop, Vue } from "vue-property-decorator";
import LanguageTranslationInputs from "./LanguageTranslationInputs.vue";

@Component({
  components: {
    LanguageTranslationInputs,
  },
})
export default class UpdateSpecificTranslations extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Prop({ required: true })
  specificTranslations!: { [orgTypeId: string]: ApplicationTranslation[] };

  @Prop({ required: true })
  selectedOrganisationTypeIds!: string[];

  @Prop({ required: true })
  translationCode!: string;

  // Data

  fetching = true;

  organisationTypes: OrganisationTypeInfos[] = [];

  // Computed Properties

  get organisationTypeService() {
    return this.container.resolve<IOrganisationTypeService>(
      SERVICES.ORGANISATIONTYPESERVICE
    );
  }

  get selectedOrganisationTypes() {
    return this.organisationTypes.filter((o) =>
      this.selectedOrganisationTypeIds.includes(o.id)
    );
  }

  // Methods

  getTranslations(orgTypeId: string) {
    return this.specificTranslations[orgTypeId] ?? [];
  }

  setTranslations(orgTypeId: string, translations: ApplicationTranslation[]) {
    const newTranslations = { ...this.specificTranslations };
    newTranslations[orgTypeId] = translations;
    this.$emit("update:specificTranslations", newTranslations);
  }

  toggleOrganisationType(organisationType: OrganisationTypeInfos) {
    let newSelectedOrganisationTypeIds = [];

    if (this.selectedOrganisationTypeIds.includes(organisationType.id)) {
      newSelectedOrganisationTypeIds = this.selectedOrganisationTypeIds.filter(
        (s) => s != organisationType.id
      );
    } else {
      newSelectedOrganisationTypeIds = [...this.selectedOrganisationTypeIds, organisationType.id];
    }

    this.$emit("update:selectedOrganisationTypeIds", newSelectedOrganisationTypeIds);
  }

  // Lifecycle

  mounted() {
    this.fetchOrganisationTypes();
  }

  async fetchOrganisationTypes(): Promise<void> {
    this.fetching = true;

    try {
      this.organisationTypes = await this.organisationTypeService.getMany();
    } finally {
      this.fetching = false;
    }
  }
}
</script>

<style scoped></style>
