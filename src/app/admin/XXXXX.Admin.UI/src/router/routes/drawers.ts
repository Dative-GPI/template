import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";
import { IMPORT_TRANSLATIONS_DRAWER_PATH, EXAMPLES_DRAWER_PATH } from "@/config";


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



    {
        path: "/translations/:translationCode/drawer",
        name: "update-translation-drawer",
        components: {
            default: () => import("@/components/translations/drawers/UpdateTranslationDrawer.vue"),
            title: SimpleTitle
        },
        meta: {
            exact: false,
            drawer: true
        }
    },
    {
        path: IMPORT_TRANSLATIONS_DRAWER_PATH,
        name: "import-translations-drawer",
        components: {
            default: () => import("@/components/translations/drawers/ImportTranslationsDrawer.vue"),
            title: SimpleTitle
        },
        meta: {
            exact: false,
            drawer: true
        }
    }
];