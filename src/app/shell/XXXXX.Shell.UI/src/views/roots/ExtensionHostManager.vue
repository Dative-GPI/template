<template>
  <div>
    <slot
      :token="token"
      :languageId="languageId"
      :languageCode="languageCode"
      :userOrganisationId="userOrganisationId"
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
  @ProvideReactive(ORGANISATION)
  get organisationId() {
    return new URL(window.location.toString()).searchParams.get(
      "organisationId"
    );
  }

  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = true;

  subscriberIds: number[] = [];

  mounted(): void {
    // this.extensionService.subscribe();
    setInterval(this.notify, 10);
    this.notify();
  }

  get token() {
    return new URL(window.location.toString()).searchParams.get("token");
  }

  get languageId() {
    return new URL(window.location.toString()).searchParams.get("languageCode");
  }

  get languageCode() {
    return new URL(window.location.toString()).searchParams.get("languageId");
  }

  get userOrganisationId() {
    return new URL(window.location.toString()).searchParams.get(
      "userOrganisationId"
    );
  }

  get extensionCommunicationService(){
    return this.container.resolve<IExtensionCommunicationService>(S.EXTENSIONCOMMUNICATIONSERVICE);
  }

  get currentRoute(){
    return this.$route;
  } 

  unmounted(){
    _.forEach(this.subscriberIds, s => {
      this.extensionCommunicationService.unsubscribe(s)
    });
  } 

  notify() {
    if(this.$route.path != "/"){//todo there is maybe a better solution 
      this.extensionCommunicationService.setHeight(document.body.scrollHeight, this.$route.path);
    }
  }

  goTo(){
    if(this.$route.meta && !this.$route.meta.drawer) {
      this.extensionCommunicationService.goTo(this.$route.path);
    } 
  }

  @Watch("currentRoute")
  onCurrentRouteChanged = this.goTo;

}
</script>