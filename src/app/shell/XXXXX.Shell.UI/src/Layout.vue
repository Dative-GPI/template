<template>
  <router-view name="default" :key="$route.fullPath"> </router-view>
</template>

<script lang="ts">
import _ from "lodash";
import { Location } from "vue-router";
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Inject } from "vue-property-decorator";

import { PROVIDER } from "@/config";
import { drawerRoutes } from "@/router";

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

  get routes() {
    const result: (
      | {
          icon: string;
          codeLabel: string;
          defaultLabel: string;
          to: Location;
          exact: boolean;
          disabled: boolean;
        }
      | { heading: string }
    )[] = [];

    const params = this.$route.params;

    _(drawerRoutes)
      .groupBy(r => r.meta.codeHeader)
      .forEach((value, key) => {
        if (key != "undefined") result.push({ heading: key });
        value.forEach(r => {
          result.push({
            icon: r.meta.icon,
            codeLabel: r.meta.drawerCodeLabel,
            defaultLabel: r.meta.drawerDefaultLabel,
            to: {
              name: r.name,
              params: r.meta.defaultParams && r.meta.defaultParams(params)
            },
            exact: !!r.meta.exact,
            disabled: !!r.meta.disabled
          });
        });
      });

    return result;
  }

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {}
}
</script>

<style>
</style>