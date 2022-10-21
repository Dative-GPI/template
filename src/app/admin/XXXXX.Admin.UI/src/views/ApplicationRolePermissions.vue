<template>
  <application-role-permissions-list
    :edit-mode="editMode"
    :role-admin-id="roleAdminId"
  />
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ApplicationRolePermissionsList from "@/components/permissions/ApplicationRolePermissionsList.vue";

@Component({
  components: {
    ApplicationRolePermissionsList
  }
})
export default class OrganisationTypeRolePermission extends Vue {
  get editMode() {
    return this.$route.hash.includes("editMode=true");
  }

  get roleAdminId() {
    return this.$route.params.roleAdminId;
  }
}
</script>
