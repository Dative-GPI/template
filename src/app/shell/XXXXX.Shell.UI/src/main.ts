import "reflect-metadata";
import Vue from 'vue';

import 'roboto-fontface/css/roboto/roboto-fontface.css';
import '@fontsource/open-sans';
import '@fontsource/montserrat';
import '@mdi/font/css/materialdesignicons.css';
import 'material-design-icons-iconfont/dist/material-design-icons.css';

import vuetify from '@/plugins/vuetify';
import "@/plugins/libs";
import "@/plugins/blurhash";

import App from '@/App.vue';
import { router } from '@/router';

import { PROVIDER } from "@/config";
import { container } from "@/di/dependencyInjector";

import "./style.css";

Vue.config.productionTip = false;

import { Shards } from "@dative-gpi/shards";
Vue.use(Shards);

import Drawer from "@/components/shared/Drawer.vue";
Vue.component("drawer", Drawer);

new Vue({
  router,
  vuetify,
  provide: {
    [PROVIDER]: container
  },
  render: h => h(App)
}).$mount('#app');
