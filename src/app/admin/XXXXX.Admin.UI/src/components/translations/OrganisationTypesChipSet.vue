<template>
  <d-chip-set :value="items" :editable="false"></d-chip-set>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Prop, Vue } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";
import { IOrganisationTypeService } from "@/interfaces";
import { OrganisationTypeInfos } from "@/domain/models";


@Component({})
export default class OrganisationTypesChipSet extends Vue {
  // Properties

  @Prop({ required: false, default: () => [] })
  value!: string[];

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  loading = false;
  organisationTypes: OrganisationTypeInfos[] = [];
  search = "";

  // Computed Properties

  get organisationTypeService(): IOrganisationTypeService {
    return this.container.resolve<IOrganisationTypeService>(
      S.ORGANISATIONTYPESERVICE
    );
  }

  get items() {
    if (!this.value) return [];

    return this.organisationTypes
      .filter((a) => this.value.includes(a.id))
      .map((a) => a.label)
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
      this.organisationTypes = await this.organisationTypeService.getMany();
    } finally {
      this.loading = false;
    }
  }
}
</script>
