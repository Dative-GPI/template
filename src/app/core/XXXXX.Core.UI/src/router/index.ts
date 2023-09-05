// Composables
import { createRouter, createWebHistory } from 'vue-router'

import { routes as templateRoutes } from "@dative-gpi/foundation-template-core-ui"

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
    children: [
      {
        path: '',
        name: 'Home',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "home" */ '@/views/Home.vue'),
      },
    ],
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes: [
    ...templateRoutes,
    ...routes
  ]
})

console.log(router.getRoutes())

export default router
