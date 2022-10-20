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
import { Component, Inject, InjectReactive, Prop, Vue, Watch } from "vue-property-decorator";

import { ORGANISATION, PROVIDER, SERVICES as S } from "@/config";
import { PermissionCategory, PermissionInfos } from "@/domain/models";
import {
  IOrganisationPermissionService,
  IPermissionService,
  IRolePermissionService,
} from "@/interfaces";

@Component({})
export default class OrganisationRolePermissionList extends Vue {
  // Properties

  @InjectReactive(ORGANISATION)
  organisationId!: string;

  @Prop({ required: true })
  roleId!: string;

  @Prop({ required: false, default: false })
  editMode!: boolean;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  fetching = true;
  saving = false;

  permissionCategories: PermissionCategory[] = [];
  organisationPermissions: PermissionInfos[] = [];
  rolePermissions: PermissionInfos[] = [];

  selectedPermissions: string[] = [];

  // Computed Properties

  get permissionService(): IPermissionService {
    return this.container.resolve<IPermissionService>(S.PERMISSIONSERVICE);
  }

  get rolePermissionService(): IRolePermissionService {
    return this.container.resolve<IRolePermissionService>(
      S.ROLEPERMISSIONSERVICE
    );
  }

  get organisationPermissionService(): IOrganisationPermissionService {
    return this.container.resolve<IOrganisationPermissionService>(
      S.ORGANISATIONPERMISSIONSERVICE
    );
  }

  get categoriesAndPermissions(): {
    id: string;
    label: string;
    options: { id: string; label: string }[];
  }[] {
    return this.permissionCategories.map((cat, index) => ({
      id: index.toString(),
      label: cat.label,
      options: this.organisationPermissions
        .filter((p) => p.code.startsWith(cat.prefix))
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
      await this.rolePermissionService.update(
        this.organisationId,
        this.roleId,
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
    this.selectedPermissions = this.rolePermissions.map((p) => p.id).slice();
  }

  // Lifecycle

  mounted(): void {
    this.fetch();
  }

  async fetch() {
    this.fetching = true;

    try {
      await Promise.all([
        this.fetchPermissionsCategories(),
        this.fetchOrganisationPermissions(),
        this.fetchRolePermissions(),
      ]);
    } finally {
      this.fetching = false;
    }
  }

  async fetchPermissionsCategories(): Promise<void> {
    this.permissionCategories = await this.permissionService.getCategories(this.organisationId);
  }

  async fetchRolePermissions() {
    this.rolePermissions = await this.rolePermissionService.getMany(
      this.organisationId, 
      this.roleId
    );
  }

  async fetchOrganisationPermissions() {
    this.organisationPermissions = await this.organisationPermissionService.getMany(
      this.organisationId
    );
  }

  @Watch("selectedPermissions")
  onPropertyChanged = this.debouncedSynchronizePermissions;

  @Watch("rolePermissions")
  onOrgTypePermissionsChanged = this.resetSelectedPermissions;

  @Watch("editMode")
  onEditModeChanged() {
    if (!this.editMode && !this.fetching) this.save();
  }
}
</script>
