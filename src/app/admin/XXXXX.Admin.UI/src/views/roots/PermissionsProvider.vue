<template>
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
  Prop,
} from "vue-property-decorator";

import { UserApplicationDetails } from "@/domain/models";
import { PROVIDER, USER_APPLICATION } from "@/config";

@Component
export default class App extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Prop({required: true, default: null})
  userApplicationId: string | null;

  mounted(): void {
    this.reset();
  }

  reset() {
    // if (this.userApplicationId)
    // Get the permissions for the v-right directive
    // this.$pm.set(permission);
  }

  @Watch("userOrganisation")
  onUserOrganisationChanged = this.reset;
}
</script>