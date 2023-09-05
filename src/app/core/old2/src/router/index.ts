import Vue from "vue";
import VueRouter from "vue-router";

import { routes as templateRoutes } from "@dative-gpi/foundation-template-core-ui/routes"

Vue.use(VueRouter);

const router = new VueRouter({
  mode: "history",
  base: import.meta.env.BASE_URL,
  routes: [
    ...templateRoutes,
    
  ],
});

export default router;
