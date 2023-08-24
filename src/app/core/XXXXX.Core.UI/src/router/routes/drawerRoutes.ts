import { DrawerRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";
import { EXAMPLES_PATH } from "@/config";

export const drawerRoutes: DrawerRouteConfig[] = [
    {
        path: EXAMPLES_PATH,
        name: "example-page",
        components: {
            default: () => import("@/views/Example.vue"),
            title: SimpleTitle,
        },
        meta: {
            drawerCodeLabel: "ui.examples.drawer.code",
            drawerDefaultLabel: "Example",
            icon: "supervised_user_circle",
            exact: true,
        },
    },
];