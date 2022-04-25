import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";

export const routes: CustomRouteConfig[] = [
    {
        path: "/organisation-types/:organisationTypeId/permissions",
        name: "organisation-type-permissions",
        components: {
            default: () => import("@/views/OrganisationTypePermissions.vue"),
            title: SimpleTitle
            // crumbs: () => import("@/components/organisationTypes/nav/OrganisationTypePermissionsCrumbs.vue"),
            // title: () => import("@/components/organisationTypes/nav/OrganisationTypeTitle.vue")
        }
    },
    {
        path: "/organisation-types/:organisationTypeId/roles/:roleId/permissions",
        name: "organisation-type-role-permissions",
        components: {
            default: () => import("@/views/OrganisationTypeRolePermissions.vue"),
            title: SimpleTitle
            // crumbs: () => import("@/components/organisationTypes/nav/OrganisationTypePermissionsCrumbs.vue"),
            // title: () => import("@/components/organisationTypes/nav/OrganisationTypeTitle.vue")
        }
    },
]