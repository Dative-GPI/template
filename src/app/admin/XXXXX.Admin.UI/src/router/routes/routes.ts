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
        path: "/test",
        name: "test",
        components: {
            default: () => import("@/views/OrganisationTypePermissions.vue"),
            title: SimpleTitle
            // crumbs: () => import("@/components/organisationTypes/nav/OrganisationTypePermissionsCrumbs.vue"),
            // title: () => import("@/components/organisationTypes/nav/OrganisationTypeTitle.vue")
        }
    }
]