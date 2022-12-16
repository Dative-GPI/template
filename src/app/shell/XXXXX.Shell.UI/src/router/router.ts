import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'

import { drawerRoutes, drawers, routes } from "./routes";

Vue.use(VueRouter)

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: ([] as RouteConfig[])
    .concat(drawers)
    .concat(drawerRoutes)
    .concat(routes)
})

export default router;