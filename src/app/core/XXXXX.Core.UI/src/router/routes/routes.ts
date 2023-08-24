import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";

export const routes: CustomRouteConfig[] = [
  {
    path: "/role-organisations/:roleId/permissions",
    name: "organisation-role-permissions",
    components: {
      default: () => import("@/views/OrganisationRolePermissions.vue"),
      title: SimpleTitle,
    },
  },
];
