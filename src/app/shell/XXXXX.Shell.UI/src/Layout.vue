<template>
  <v-app id="inspire">
    <v-main>
      <v-container fluid class="py-0 px-1 pl-sm-5 pl-md-5 pl-lg-10 pr-sm-5">
        <router-view name="default" :key="$route.fullPath"> </router-view>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import _ from "lodash";
import { Location } from "vue-router";
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Inject, InjectReactive } from "vue-property-decorator";

import { USER, ORGANISATION, PROVIDER, SERVICES as S } from "@/config";
import { drawerRoutes } from "@/router";

import NotificationsDrawer from "@/components/shared/NotificationsDrawer.vue";
import AppActions from "@/components/shared/AppActions.vue";
import { onCollectionChanged } from "./tools";

@Component({
  components: {
    NotificationsDrawer,
    AppActions,
  },
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
      .groupBy((r) => r.meta.codeHeader)
      .forEach((value, key) => {
        if (key != "undefined") result.push({ heading: key });
        value.forEach((r) => {
          result.push({
            icon: r.meta.icon,
            codeLabel: r.meta.drawerCodeLabel,
            defaultLabel: r.meta.drawerDefaultLabel,
            to: {
              name: r.name,
              params: r.meta.defaultParams && r.meta.defaultParams(params),
            },
            exact: !!r.meta.exact,
            disabled: !!r.meta.disabled,
          });
        });
      });

    return result;
  }

  mounted(): void {
    window.top!.postMessage('hello', '*')
    this.fetch();
  }

  async fetch(): Promise<void> {
  }
}
</script>

<style>
</style>