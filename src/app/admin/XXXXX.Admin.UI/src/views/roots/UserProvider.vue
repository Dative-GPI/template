<template>
  <div v-if="fetching || !user">
    <div v-if="fetching">Loading user</div>
    <landing-page v-else @login="fetch" />
  </div>
  <div v-else><slot></slot></div>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import {
  Component,
  Vue,
  Inject,
  ProvideReactive,
  Prop,
  Watch,
} from "vue-property-decorator";

import { UserDetails } from "@/domain/models";

import { PROVIDER, USER, SERVICES as S } from "@/config";
import { IUserService } from "@/interfaces";

import LandingPage from "./LandingPage.vue";

@Component({
  components: {
    LandingPage,
  },
})
export default class UserProvider extends Vue {
  @Prop({ required: false, default: () => null })
  userId!: string | null;

  @ProvideReactive(USER)
  user: UserDetails | null = null;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  fetching = true;

  mounted(): void {
    this.fetch();
  }

  async fetch(): Promise<void> {
    this.fetching = true;
    try {
      this.user = await this.userService.getCurrent();

      this.$emit("input", this.user.id);
    } catch {
      this.$emit("show");
    } finally {
      this.fetching = false;
    }
  }

  get userService(): IUserService {
    return this.container.resolve<IUserService>(S.USERSERVICE);
  }

  @Watch("userId")
  onUserIdChanged() {
    if (this.userId == null) {
      this.user = null;
    }
  }
}
</script>