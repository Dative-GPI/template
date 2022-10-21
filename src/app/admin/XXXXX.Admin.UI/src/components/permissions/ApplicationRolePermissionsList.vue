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
import { PermissionAdminCategory, PermissionAdminInfos } from "@/domain/models";
import {
  IPermissionAdminService,
  IRoleAdminPermissionService,
} from "@/interfaces";

@Component({})
export default class ApplicationRolePermissionList extends Vue {
  // Properties

  @Prop({ required: true })
  roleAdminId!: string;

  @Prop({ required: false, default: false })
  editMode!: boolean;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  fetching = true;
  saving = false;

  permissionAdminCategories: PermissionAdminCategory[] = [];
  permissionAdmins: PermissionAdminInfos[] = [];
  roleAdminPermissions: PermissionAdminInfos[] = [];

  selectedPermissions: string[] = [];

  // Computed Properties

  get permissionAdminService(): IPermissionAdminService {
    return this.container.resolve<IPermissionAdminService>(S.PERMISSIONADMINSERVICE);
  }

  get roleAdminPermissionService(): IRoleAdminPermissionService {
    return this.container.resolve<IRoleAdminPermissionService>(
      S.ROLEADMINPERMISSIONSERVICE
    );
  }

  get categoriesAndPermissions(): {
    id: string;
    label: string;
    options: { id: string; label: string }[];
  }[] {
    return this.permissionAdminCategories.map((cat, index) => ({
      id: index.toString(),
      label: cat.label,
      options: this.permissionAdmins
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
      await this.roleAdminPermissionService.update(
        this.roleAdminId,
        this.selectedPermissions
      );
    } finally {
      this.saving = false;
    }
  }

  debouncedSynchronizePermissions() {
    return _.debounce(this.synchronizePermissions, 2000)();
  }

  async synchronizePermissions() {
    if (!this.editMode) return;
    await this.save();
  }

  resetSelectedPermissions() {
    this.selectedPermissions = this.roleAdminPermissions.map((p) => p.id).slice();
  }

  // Lifecycle

  mounted(): void {
    this.fetch();
  }

  async fetch() {
    this.fetching = true;

    try {
      await Promise.all([
        this.fetchPermissionAdminCategories(),
        this.fetchPermissionAdmins(),
        this.fetchRoleAdminPermissions(),
      ]);
    } finally {
      this.fetching = false;
    }
  }

  async fetchPermissionAdminCategories(): Promise<void> {
    this.permissionAdminCategories = await this.permissionAdminService.getCategories();
  }

  async fetchRoleAdminPermissions() {
    this.roleAdminPermissions = await this.roleAdminPermissionService.getMany(
      this.roleAdminId
    );
  }

  async fetchPermissionAdmins() {
    this.permissionAdmins = await this.permissionAdminService.getMany();
  }

  @Watch("selectedPermissions")
  onPropertyChanged = this.debouncedSynchronizePermissions;

  @Watch("roleAdminPermissions")
  onRoleAdminPermissionsChanged = this.resetSelectedPermissions;

  @Watch("editMode")
  onEditModeChanged() {
    if (!this.editMode && !this.fetching) this.save();
  }
}
</script>
