import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";

export const routes: CustomRouteConfig[] = [
  {
    path: "/applications/exemples",
    name: "exemples-drawer-view",
    components: {
      default: () => import("@/views/DrawerExemple.vue"),
      title: SimpleTitle,
    },
    meta: {
      exact: true,
    },
  },
  {
    path: "/applications/exemples/drawer",
    name: "exemples-drawer",
    components: {
      default: () => import("@/components/drawer.vue"),
      title: SimpleTitle,
    },
    meta: {
      exact: true,
    },
  },
];
