<template>
  <div>
    <slot :token="token" :languageId="languageId" :languageCode="languageCode" :userOrganisationId="userOrganisationId" />
  </div>
</template>

<script lang="ts">
import _ from "lodash";
import { DependencyContainer } from "tsyringe";
import { Component, Inject, Vue } from "vue-property-decorator";

import {} from "@/domain/models";
import { PROVIDER, SERVICES as S } from "@/config";

@Component({})
export default class ExtensionHostManager extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = true;

  lastMessage: any = null;

  mounted(): void {
    this.subscribe();

    setInterval(this.notify, 10);
    this.notify();
  }

  get token(){
    return new URL(window.location.toString()).searchParams.get("token");
  }

  get languageId(){
    return new URL(window.location.toString()).searchParams.get("languageCode");
  }

  get languageCode(){
    return new URL(window.location.toString()).searchParams.get("languageId");
  }

  get userOrganisationId(){
    return new URL(window.location.toString()).searchParams.get("userOrganisationId");
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
    const payload = {
      height: document.body.scrollHeight,
      title: "Test"
    };

    if (!_.isEqual(this.lastMessage, payload)) {
      this.lastMessage = payload;
      this.sendMessage(payload);
    }
  }

  sendMessage = _.debounce((payload: any) => {
    if (window.top) {
      window.top.postMessage(JSON.stringify(payload), "*");
    }
  }, 50);
}
</script>