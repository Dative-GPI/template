<template>
  <v-app ref=appz>
    <v-fade-transition mode="out-in">
      <layout />
    </v-fade-transition>
  </v-app>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { PROVIDER } from "@/config";

import axios from "@/plugins/axios";

import Layout from "@/Layout.vue";
import AxiosSnackbar from "@/components/shared/AxiosSnackbar.vue";

@Component({
  components: {
    Layout,
    AxiosSnackbar,
  },
})
export default class App extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;


  fetching = true;
  
  interval = 0;
  scrollHeight = 0; 

  mounted(): void {
    this.interval = setInterval(() => {
      this.scrollHeight = document.body.scrollHeight;
    }, 100);
    window.addEventListener(
      "message",
      (event) => {
        if (event.origin !== "https://foundation.localhost") {
          return;
        }

        if (event.source instanceof Window) {
          console.log(event);
          event.source.postMessage(
            document.documentElement.scrollHeight,
            event.origin
          );
        }
      },
      false
    );
    this.sendHeight();
  }

  sendHeight(){
    window.top!.postMessage(this.scrollHeight, "*");
  }

  @Watch("scrollHeight")
  onRouterChange = this.sendHeight;
}
</script>

<style>
a {
  text-decoration: none;
}
</style>