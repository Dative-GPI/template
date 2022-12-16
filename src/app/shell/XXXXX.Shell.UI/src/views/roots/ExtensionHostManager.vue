<template>
  <div>
    <slot
      :token="token"
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
  Watch,
} from "vue-property-decorator";
import { Route } from "vue-router";

import {
  LANGUAGE_CODE,
  ORGANISATION,
  PROVIDER,
  SERVICES as S,
  TOKEN,
} from "@/config";
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

  @ProvideReactive(TOKEN)
  get token() {
    return new URL(window.location.toString()).searchParams.get("token");
  }

  @ProvideReactive(LANGUAGE_CODE)
  get languageCode() {
    return new URL(window.location.toString()).searchParams.get("languageCode");
  }

  @Inject(PROVIDER)
  container!: DependencyContainer;

  // Data

  subscriberIds: number[] = [];

  // Computed Properties

  get extensionCommunicationService() {
    return this.container.resolve<IExtensionCommunicationService>(
      S.EXTENSIONCOMMUNICATIONSERVICE
    );
  }

  get currentRoute() {
    return this.$route;
  }

  get userOrganisationId() {
    return new URL(window.location.toString()).searchParams.get(
      "userOrganisationId"
    );
  }

  // Methods

  notify() {
    if (this.$route.path != "/") {
      //todo there is maybe a better solution
      this.extensionCommunicationService.setHeight(
        document.body.scrollHeight,
        this.$route.path
      );
    }
  }

  goTo(newRoute: Route, prevRoute: Route) {
    if (!prevRoute.name) return; // Do not notify the host about the initial route (he already knows about it)

    if (newRoute.meta && !newRoute.meta.drawer) {
      this.extensionCommunicationService.goTo(newRoute.path);
    }
  }

  // Lifecycle

  mounted(): void {
    setInterval(this.notify, 10);
    this.notify();
  }

  beforeDestroy() {
    _.forEach(this.subscriberIds, (s) => {
      this.extensionCommunicationService.unsubscribe(s);
    });
  }

  @Watch("currentRoute")
  onCurrentRouteChanged = this.goTo;
}
</script>
