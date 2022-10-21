<template>
  <div>
    <slot
      :token="token"
      :languageCode="languageCode"
      :userApplicationId="userApplicationId"
    />
  </div>
</template>

<script lang="ts">
import _ from "lodash";
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Inject,
  ProvideReactive,
  Vue,
  Watch
} from "vue-property-decorator";

import { ORGANISATION, PROVIDER, SERVICES as S} from "@/config";
import { IExtensionCommunicationService } from "@/interfaces";

@Component({})
export default class ExtensionHostManager extends Vue {
  // Properties

  @ProvideReactive(ORGANISATION)
  get organisationId() {
    return new URL(window.location.toString()).searchParams.get(
      "organisationId"
    );
  }

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  fetching = true;
  subscriberIds: number[] = [];

  // Computed Properties

  get token() {
    return new URL(window.location.toString()).searchParams.get("token");
  }

  get languageCode() {
    return new URL(window.location.toString()).searchParams.get("languageCode");
  }

  get userApplicationId() {
    return new URL(window.location.toString()).searchParams.get(
      "userApplicationId"
    );
  }

  get extensionCommunicationService(){
    return this.container.resolve<IExtensionCommunicationService>(S.EXTENSIONCOMMUNICATIONSERVICE);
  }

  get currentRoute(){
    return this.$route;
  } 

  // Methods

  goTo(){
    if(this.$route.meta && !this.$route.meta.drawer) {
      this.extensionCommunicationService.goTo(this.$route.path);
    } 
  }

  // Lifecycle

  mounted(): void {
    setInterval(this.notify, 10);
    this.notify();
  }

  beforeDestroy(){
    _.forEach(this.subscriberIds, s => {
      this.extensionCommunicationService.unsubscribe(s)
    });
  } 

  notify() {
    if(this.$route.path != "/"){//todo there is maybe a better solution 
      this.extensionCommunicationService.setHeight(document.body.scrollHeight, this.$route.path);
    }
  }

  @Watch("currentRoute")
  onCurrentRouteChanged = this.goTo;
}
</script>