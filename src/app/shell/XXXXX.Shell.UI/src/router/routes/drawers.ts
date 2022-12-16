import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";

import { EXAMPLES_DRAWER_PATH } from "@/config";

export const drawers: CustomRouteConfig[] = [
    {
      path: EXAMPLES_DRAWER_PATH,
      name: "example-drawer",
      components: {
        default: () => import("@/components/example/ExampleDrawer.vue"),
        title: SimpleTitle,
      },
      meta: {
        exact: true,
        drawer: true
      },
    },    
]