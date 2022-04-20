import "reflect-metadata";
import Vue from 'vue'

import 'roboto-fontface/css/roboto/roboto-fontface.css'
import '@fontsource/open-sans'
import '@fontsource/montserrat'
import '@mdi/font/css/materialdesignicons.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

import vuetify from '@/plugins/vuetify';
import "@/plugins/libs";
import "@/plugins/blurhash";

import App from '@/App.vue'
import { router } from '@/router'

import { PROVIDER } from "@/config";
import { container } from "@/di/dependencyInjector";

import "./style.css";

import { Shards } from "@dative-gpi/shards";

Vue.config.productionTip = false

Vue.use(Shards);

new Vue({
  router,
  vuetify,
  provide: {
    [PROVIDER]: container
  },
  render: h => h(App)
}).$mount('#app');
