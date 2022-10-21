import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";

export const routes: CustomRouteConfig[] = [
  {
    path: "/organisation-types/:organisationTypeId/permissions",
    name: "organisation-type-permissions",
    components: {
      default: () => import("@/views/OrganisationTypePermissions.vue"),
      title: SimpleTitle
    }
  },
  {
    path: "/organisation-types/:organisationTypeId/roles/:roleId/permissions",
    name: "organisation-type-role-permissions",
    components: {
      default: () => import("@/views/OrganisationTypeRolePermissions.vue"),
      title: SimpleTitle
    }
  },
  {
    path: "/role-admin/:roleAdminId/permissions",
    name: "application-role-permissions",
    components: {
      default: () => import("@/views/ApplicationRolePermissions.vue"),
      title: SimpleTitle
    },
  },
  {
    path: "/application-translations",
    name: "application-translations",
    components: {
      default: () => import("@/views/Translations.vue"),
      title: SimpleTitle,
    },
  },
];