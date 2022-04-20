<template>
  <div v-if="fetching">Loading routes</div>
  <div v-else>
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  Watch,
} from "vue-property-decorator";

import { ApplicationRoute } from "@/domain/models";

import {
  PROVIDER,
  SERVICES as S,
} from "@/config";
import { IRouteService } from "@/interfaces";
import { drawerRoutes, routes } from "@/routes";

@Component({
  components: {},
})
export default class RoutesProvider extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = true;

  get routeService(): IRouteService {
    return this.container.resolve<IRouteService>(S.ROUTESERVICE);
  }

  routes: ApplicationRoute[] = [];

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {
    this.fetching = true;

    try {
      const routes = await this.routeService.getMany();
      this.routes = routes.map(r => ({
        components: {
          default: () => import("@/views/extensions/ExtensionPageHost.vue"),
          title: () => import("@/views/extensions/ExtensionPageTitle.vue")
        },
        path: r.path,
        name: r.name,
        meta: {
          showOnDrawer: r.showOnDrawer,
          drawerCategory: r.drawerCategory,
          drawerIcon: r.drawerIcon,
          drawerLabel: r.drawerLabel,
          exact: r.exact,
          fullscreen: true
        },
        props: {
          default: {
            uri: r.uri,
            extensionId: r.extensionId
          },
          title: {
            uri: r.uri,
            extensionId: r.extensionId
          }
        }
      }))

    } finally {
      this.fetching = false;
      // un jour c'est le back qui donnera toutes les routes en fonction des droits de l'utilisateur peut-être

      for (const item of [...drawerRoutes, ...routes, ...this.routes]) {
        this.$router.addRoute(item);
      }
    }
  }
}
</script>

<style>
</style>