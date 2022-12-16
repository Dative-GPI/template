<template>
  <d-select
    v-bind="$attrs"
    v-on="$listeners"
    :items="organisationTypes"
    :loading="loading"
    item-text="label"
    item-value="id"
  />
</template>


<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";
import { IOrganisationTypeService } from "@/interfaces";
import { OrganisationTypeInfos } from "@/domain/models";

@Component({})
export default class SelectOrganisationType extends Vue {
  // Properties

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  loading = false;
  organisationTypes: OrganisationTypeInfos[] = [];

  // Computed properties

  get organisationTypeService(): IOrganisationTypeService {
    return this.container.resolve<IOrganisationTypeService>(S.ORGANISATIONTYPESERVICE);
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
