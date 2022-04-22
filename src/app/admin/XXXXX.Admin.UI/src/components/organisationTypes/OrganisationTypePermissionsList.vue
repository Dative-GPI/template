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
  IPermissionService
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

  permissionCategories: PermissionCategory[] = [];
  permissions: PermissionInfos[] = [];
  organisationTypePermissions: PermissionInfos[] = [];

  items: string[] = [];

  // Computed Properties

  get permissionService(): IPermissionService {
    return this.container.resolve<IPermissionService>(S.PERMISSIONSERVICE);
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
      options: this.permissions
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
    this.fetchPermissions();
    this.fetchOrganisationTypePermissions();
  }

  async fetchPermissionsCategories(): Promise<void> {
    this.permissionCategories = await this.permissionService.getCategories();
  }

  async fetchPermissions() {
    this.fetching = true;
    try {
      this.permissions = await this.permissionService.getMany();
    } finally {
      this.fetching = false;
    }
  }

  async fetchOrganisationTypePermissions() {
    this.fetching = true;
    try {
      this.organisationTypePermissions = await this.organisationTypePermissionService.getMany(
        this.organisationTypeId
      );
    } finally {
      this.fetching = false;
    }
  }

  async save() {
    await this.organisationTypePermissionService.update(
      this.organisationTypeId,
      this.items
    );
  }

  reset() {
    this.items = this.organisationTypePermissions.map(p => p.id).slice();
  }

  @Watch("items")
  onPropertyChanged = _.debounce(() => {
    if (this.editMode) this.save();
  }, 5000);

  @Watch("organisationTypePermissions")
  onOrgTypePermissionsChanged = this.reset;

  @Watch("editMode")
  onEditModeChanged() {
    if (!this.editMode) this.save();
  }
}
</script>
