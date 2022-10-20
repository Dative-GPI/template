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
      default: () => import("@/components/ExempleDrawer.vue"),
      title: SimpleTitle,
    },
    meta: {
      exact: true,
      drawer: true
    },
  },
  {
    path: "/applications/goto",
    name: "exemples-goto",
    components: {
      default: () => import("@/views/GoToExemple.vue"),
      title: SimpleTitle,
    },
    meta: {
      exact: true,
    },
  },

  {
    path: "/role-organisations/:roleId/permissions",
    name: "organisation-role-permissions",
    components: {
      default: () => import("@/views/OrganisationRolePermissions.vue"),
      title: SimpleTitle,
    },
  },
];
