<template>
  <organisation-role-permissions-list :edit-mode="editMode" :role-id="roleId" />
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import OrganisationRolePermissionsList from "@/components/permissions/OrganisationRolePermissionsList.vue";

@Component({
  components: {
    OrganisationRolePermissionsList
  }
})
export default class OrganisationRolePermissions extends Vue {
  // Properties
  // Data
  // Computed Properties

  get editMode() {
    return this.$route.hash.includes("editMode=true");
  }

  get roleId() {
    return this.$route.params.roleId;
  }

  // Methods
  // Lifecycle
}
</script>
