import { CustomRouteConfig } from "./interfaces";

import SimpleTitle from "@/components/shared/SimpleTitle.vue";
import { IMPORT_TRANSLATIONS_DRAWER_URL } from "@/config";

export const drawers: CustomRouteConfig[] = [
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
        path: IMPORT_TRANSLATIONS_DRAWER_URL,
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
]