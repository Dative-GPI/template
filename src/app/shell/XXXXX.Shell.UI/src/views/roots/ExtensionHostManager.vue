<template>
  <div>
    <slot />
  </div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import {} from "@/domain/models";
import { PROVIDER, SERVICES as S } from "@/config";

@Component({})
export default class ExtensionHostManager extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = true;

  title = "";
  lastHeight = 0;

  mounted(): void {
    this.subscribe();

    setInterval(this.notify, 100);
    this.notify();
  }

  unmounted = this.unsubscribe;

  subscribe() {
    window.addEventListener("message", this.onMessageReceived, false);
  }

  unsubscribe() {
    window.removeEventListener("message", this.onMessageReceived, false);
  }

  onMessageReceived(event: MessageEvent) {
    if (event.source) {
    }
  }

  notify() {
    if (window.top)
      window.top.postMessage(
        JSON.stringify({
          height: document.body.clientHeight,
          title: "Test",
        }),
        "*"
      );
  }
}
</script>

<style scoped>
.d-extension-container {
  width: 100%;
  height: calc(100vh - 100px);
  border: 0;
}
</style>