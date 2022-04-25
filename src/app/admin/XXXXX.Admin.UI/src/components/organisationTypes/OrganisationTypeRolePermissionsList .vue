<template>
  <d-switch-grid
    class="mt-4"
    :categories="formattedPermissions"
    v-model="items"
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
  IRolePermissionService
} from "@/interfaces";

@Component({})
export default class OrganisationTypeRolePermissionList extends Vue {
  // Properties
  @Prop({ required: true })
  organisationTypeId!: string;

  @Prop({ required: true })
  roleId!: string;

  @Prop({ required: false, default: false })
  editMode!: boolean;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data
  fetching = true;

  permissionCategories: PermissionCategory[] = [];
  rolePermissions: PermissionInfos[] = [];
  organisationTypePermissions: PermissionInfos[] = [];

  items: string[] = [];

  // Computed Properties

  get permissionService(): IPermissionService {
    return this.container.resolve<IPermissionService>(S.PERMISSIONSERVICE);
  }

  get rolePermissionService(): IRolePermissionService {
    return this.container.resolve<IRolePermissionService>(
      S.ROLEPERMISSIONSERICE
    );
  }

  get organisationTypePermissionService(): IOrganisationTypePermissionService {
    return this.container.resolve<IOrganisationTypePermissionService>(
      S.ORGANISATIONTYPEPERMISSIONSERVICE
    );
  }

  get formattedPermissions(): {
    id: string;
    label: string;
    options: { id: string; label: string }[];
  }[] {
    return this.permissionCategories.map((cat, index) => ({
      id: index.toString(),
      label: cat.label,
      options: this.organisationTypePermissions
        .filter(p => p.code.startsWith(cat.prefix))
        .map(p => ({
          id: p.id,
          label: p.label
        }))
    }));
  }

  // Methods

  mounted(): void {
    this.fetchPermissionsCategories();
    this.fetchOrganisationTypePermissions();
    this.fetchRolePermissions();
  }

  async fetchPermissionsCategories(): Promise<void> {
    this.permissionCategories = await this.permissionService.getCategories();
  }

  async fetchOrganisationTypePermissions() {
    this.organisationTypePermissions = await this.organisationTypePermissionService.getMany(
      this.organisationTypeId
    );
  }

  async fetchRolePermissions() {
    this.fetching = true;
    try {
      this.rolePermissions = await this.rolePermissionService.getMany(
        this.roleId
      );
    } finally {
      this.fetching = false;
    }
  }

  async save() {
    await this.rolePermissionService.update(
      this.roleId,
      this.items
    );
  }

  reset() {
    this.items = this.rolePermissions.map(p => p.id).slice();
  }

  @Watch("items")
  onPropertyChanged = _.debounce(() => {
    console.log("editMode " + this.editMode)
    if (this.editMode) this.save();
  }, 5000);

  @Watch("rolePermissions")
  onOrgTypePermissionsChanged = this.reset;

  @Watch("editMode")
  onEditModeChanged() {
    if (!this.editMode && !this.fetching) this.save();
  }
}
</script>
