<template>
  <!-- <div></div> -->
  <div><slot></slot></div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  InjectReactive,
  Watch,
} from "vue-property-decorator";

import { UserApplicationDetails } from "@/domain/models";
import { PROVIDER, USER_APPLICATION } from "@/config";

@Component
export default class App extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @InjectReactive(USER_APPLICATION)
  userApplication!: UserApplicationDetails | null;


  mounted(): void {
    this.reset();
  }

  reset() {
    // if (this.userApplication)
    // Get the permissions for the v-right directive
    // this.$pm.set(this.userOrganisation.permissions);
  }

  @Watch("userOrganisation")
  onUserOrganisationChanged = this.reset;
}
</script>