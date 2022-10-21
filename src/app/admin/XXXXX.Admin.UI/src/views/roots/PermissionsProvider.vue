<template>
  <div>
    <slot></slot>
  </div>
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
import { IPermissionAdminService } from "@/interfaces";

@Component
export default class PermissionsProvider extends Vue {
  // Properties

  @InjectReactive(ORGANISATION)
  organisationId!: string;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Prop({ required: true })
  userApplicationId!: string;

  // Data

  fetching = true;

  // Computed Properties

  get permissionAdminService(): IPermissionAdminService {
    return this.container.resolve<IPermissionAdminService>(
      SERVICES.PERMISSIONADMINSERVICE
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
      const permissions = await this.permissionAdminService.getCurrent();

      // Get the permissions for the v-right directive
      this.$pm.set(permissions);
    } finally {
      this.fetching = false;
    }
  }

  @Watch("userApplicationId")
  onUserApplicationIdChanged = this.fetch;
}
</script>
