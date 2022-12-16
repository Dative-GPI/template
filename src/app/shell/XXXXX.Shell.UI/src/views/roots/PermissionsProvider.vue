<template>
  <div v-if="fetching"></div>
  <div v-else><slot></slot></div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  Watch,
  Prop,
  InjectReactive,
} from "vue-property-decorator";

import { ORGANISATION, PROVIDER, SERVICES } from "@/config";
import { IPermissionService } from "@/interfaces";

@Component
export default class PermissionsProvider extends Vue {
  // Properties

  @InjectReactive(ORGANISATION)
  organisationId!: string;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Prop({ required: true })
  userOrganisationId!: string;

  // Data

  fetching = true;

  // Computed Properties

  get permissionService(): IPermissionService {
    return this.container.resolve<IPermissionService>(
      SERVICES.PERMISSIONSERVICE
    );
  }

  // Methods
  // Lifecycle

  mounted(): void {
    this.fetch();
  }

  async fetch() {
    this.fetching = true;

    try {
      const permissions = await this.permissionService.getCurrent(
        this.organisationId
      );

      // Get the permissions for the v-right directive
      this.$pm.set(permissions);
    } finally {
      this.fetching = false;
    }
  }

  @Watch("userOrganisationId")
  onUserOrganisationIdChanged = this.fetch;
}
</script>
