<template>
  <div v-if="fetching || !application">Loading application</div>
  <div v-else>
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  ProvideReactive,
  Watch,
} from "vue-property-decorator";

import { ApplicationDetails } from "@/domain/models";
import {
  APPLICATION,
  IMAGE_THUMBNAIL_URL,
  PROVIDER,
  SERVICES as S,
} from "@/config";
import { IApplicationService } from "@/interfaces";
import { autoUpdate } from "@/tools";

@Component({
  components: {},
})
export default class ApplicationProvider extends Vue {
  @ProvideReactive(APPLICATION)
  application: ApplicationDetails | null = null;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = true;

  get applicationService(): IApplicationService {
    return this.container.resolve<IApplicationService>(S.APPLICATIONSERVICE);
  }

  mounted(): void {
    this.fetch();

    this.applicationService.subscribe(
      "update",
      autoUpdate(
        (a) => !!this.application && a.id == this.application.id,
        (a) => (this.application = a)
      )
    );
  }

  async fetch(): Promise<void> {
    this.fetching = true;

    try {
      this.application = await this.applicationService.get();
    } finally {
      this.fetching = false;
    }
  }

  update() {
    if (!this.application) return;
    document.title = this.application.label + " - Admin";

    let link: HTMLLinkElement | null =
      document.querySelector("link[rel~='icon']");
    if (!link) {
      link = document.createElement("link");
      link.rel = "icon";
      document.getElementsByTagName("head")[0].appendChild(link);
    }
    link.href =
      (this.application.logoId &&
        IMAGE_THUMBNAIL_URL(this.application.logoId)) ||
      "https://avatars.githubusercontent.com/u/92268243?s=200&v=4";
  }

  @Watch("application")
  onApplicationChanged = this.update;
}
</script>

<style>
a {
  text-decoration: none;
}
</style>