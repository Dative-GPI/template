<template>
  <router-view name="default"> </router-view>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Inject } from "vue-property-decorator";

import { PROVIDER, SERVICES as S } from "@/config";

import NotificationsDrawer from "@/components/shared/NotificationsDrawer.vue";
import AppActions from "@/components/shared/AppActions.vue";

@Component({
  components: {
    NotificationsDrawer,
    AppActions
  }
})
export default class Layout extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = false;

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {}
}
</script>