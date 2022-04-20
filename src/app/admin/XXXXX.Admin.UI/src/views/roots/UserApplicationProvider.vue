<template>
  <div v-if="fetching && !userApplication">Loading user application</div>
  <div v-else-if="userApplication && !fetching"><slot></slot></div>
  <div v-else>You don't seem to be on the right place, be carefull</div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  ProvideReactive,
  InjectReactive,
} from "vue-property-decorator";

import { UserApplicationDetails, UserDetails } from "@/domain/models";
import { PROVIDER, SERVICES as S, USER, USER_APPLICATION } from "@/config";
import { IUserApplicationService } from "@/interfaces";

@Component({
  components: {},
})
export default class UserApplicationProvider extends Vue {
  @Inject(PROVIDER)
  container!: DependencyContainer;

  @InjectReactive(USER)
  user!: UserDetails;

  @ProvideReactive(USER_APPLICATION)
  userApplication: UserApplicationDetails | null = null;

  get userApplicationService(): IUserApplicationService {
    return this.container.resolve<IUserApplicationService>(
      S.USERAPPLICATIONSERVICE
    );
  }

  fetching = true;

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {
    this.fetching = true;

    try {
      this.userApplication = await this.userApplicationService.getCurrent();
    } finally {
      this.fetching = false;
    }
  }
}
</script>