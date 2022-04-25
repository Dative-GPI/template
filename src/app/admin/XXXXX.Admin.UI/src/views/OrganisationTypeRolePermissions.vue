<template>
  <organisation-type-role-permissions-list
    :edit-mode="editMode"
    :organisation-type-id="organisationTypeId"
    :role-id="roleId"
  />
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import OrganisationTypeRolePermissionsList from "@/components/organisationTypes/OrganisationTypeRolePermissionsList .vue";

@Component({
  components: {
    OrganisationTypeRolePermissionsList
  }
})
export default class OrganisationTypeRolePermission extends Vue {
  get editMode() {
    return this.$route.hash.includes("editMode=true");
  }

  get organisationTypeId() {
    return this.$route.params.organisationTypeId;
  }

  get roleId() {
    return this.$route.params.roleId;
  }
}
</script>
