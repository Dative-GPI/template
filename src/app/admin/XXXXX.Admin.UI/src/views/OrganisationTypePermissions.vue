<template>
  <organisation-type-permissions-list
    :edit-mode="editMode"
    :organisation-type-id="organisationTypeId"
  />
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import OrganisationTypePermissionsList from "@/components/permissions/OrganisationTypePermissionsList.vue";

@Component({
  components: {
    OrganisationTypePermissionsList
  }
})
export default class OrganisationTypePermission extends Vue {
  get editMode() {
    return this.$route.hash.includes("editMode=true");
  }

  get organisationTypeId() {
    return this.$route.params.organisationTypeId;
  }
}
</script>
