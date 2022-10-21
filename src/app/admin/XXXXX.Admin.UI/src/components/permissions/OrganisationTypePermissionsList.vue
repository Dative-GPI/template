<template>
  <d-switch-grid
    class="mt-4"
    :categories="categoriesAndPermissions"
    v-model="selectedPermissions"
    :editable="editMode"
    select-all-btns
    select-by-category-btns
  />
</template>

<script lang="ts">
import _ from "lodash";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Prop, Vue, Watch } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";
import { PermissionCategory, PermissionInfos } from "@/domain/models";
import {
  IOrganisationTypePermissionService,
  IPermissionService,
} from "@/interfaces";

@Component({})
export default class OrganisationTypePermissionList extends Vue {
  // Properties

  @Prop({ required: true })
  organisationTypeId!: string;

  @Prop({ required: false, default: false })
  editMode!: boolean;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  fetching = true;
  saving = false;

  permissionCategories: PermissionCategory[] = [];
  permissions: PermissionInfos[] = [];
  organisationTypePermissions: PermissionInfos[] = [];

  selectedPermissions: string[] = [];

  // Computed Properties

  get permissionService(): IPermissionService {
    return this.container.resolve<IPermissionService>(S.PERMISSIONSERVICE);
  }

  get organisationTypePermissionService(): IOrganisationTypePermissionService {
    return this.container.resolve<IOrganisationTypePermissionService>(
      S.ORGANISATIONTYPEPERMISSIONSERVICE
    );
  }

  get categoriesAndPermissions(): {
    id: string;
    label: string;
    options: { id: string; label: string }[];
  }[] {
    return this.permissionCategories.map((category, index) => ({
      id: index.toString(),
      label: category.label,
      options: this.permissions
        .filter((p) => p.code.startsWith(category.prefix))
        .map((p) => ({
          id: p.id,
          label: p.label,
        })),
    }));
  }

  // Methods

  async save() {
    this.saving = true;

    try {
      await this.organisationTypePermissionService.update(
        this.organisationTypeId,
        this.selectedPermissions
      );
    } finally {
      this.saving = false;
    }
  }

  debouncedSynchronizePermissions() {
    return _.debounce(this.synchronizePermissions, 500)();
  }

  async synchronizePermissions() {
    if (!this.editMode) return;
    await this.save();
  }

  resetSelectedPermissions() {
    this.selectedPermissions = this.organisationTypePermissions
      .map((p) => p.id)
      .slice();
  }

  // Lifecycle

  mounted(): void {
    this.fetch();
  }

  async fetch() {
    this.fetching = true;

    try {
      await Promise.all([
        this.fetchPermissions(),
        this.fetchPermissionsCategories(),
        this.fetchOrganisationTypePermissions(),
      ]);
    } finally {
      this.fetching = false;
    }
  }

  async fetchPermissionsCategories(): Promise<void> {
    this.permissionCategories = await this.permissionService.getCategories();
  }

  async fetchPermissions() {
    this.permissions = await this.permissionService.getMany();
  }

  async fetchOrganisationTypePermissions() {
    this.organisationTypePermissions = await this.organisationTypePermissionService.getMany(
      this.organisationTypeId
    );
  }

  @Watch("selectedPermissions")
  onSelectedPermissionsChanged = this.debouncedSynchronizePermissions;

  @Watch("organisationTypePermissions")
  onOrganisationTypePermissionsChanged = this.resetSelectedPermissions;

  @Watch("editMode")
  onEditModeChanged() {
    if (!this.editMode && !this.fetching) this.save();
  }
}
</script>
