<template>
  <div>
    <v-snackbar v-if="snacks.length > 0" :value="true" top right :timeout="-1">
      <div class="snackbar-text">
        {{ snacks[snacks.length - 1] }}

        <template v-if="snacks.length > 1">
          &nbsp;({{ snacks.length - 1 }} {{ $tr("ui.common.more", "more") }})
        </template>
      </div>

      <template v-slot:action="{ attrs }">
        <v-btn color="pink" text @click="close" v-bind="attrs">
          {{ $tr("ui.common.close", "Close") }}
        </v-btn>
      </template>
    </v-snackbar>
    
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

import axios, { AxiosRequestConfig } from "axios";

@Component({
  components: {},
})
export default class NetworkManager extends Vue {
  // Properties

  @Prop({ required: false, default: () => null })
  token!: string | null;

  @Prop({ required: false, default: () => null })
  languageCode!: string | null;

  @Prop({ required: false, default: () => null })
  userOrganisationId!: string | null;

  // Data

  snacks: string[] = [];

  // Computed properties
  // Methods

  close(): void {
    this.snacks.pop();
  }

  beforeMount(): void {
    axios.interceptors.request.use(this.requestInterceptor);
    axios.interceptors.response.use(undefined, this.responseInterceptor);
  }

  requestInterceptor(config: AxiosRequestConfig) {
    if (this.token != null)
      config.headers.common["Authorization"] = "Bearer " + this.token;

    if (this.languageCode != null)
      config.headers.common["Accept-Language"] = this.languageCode;

    if (this.userOrganisationId != null)
      config.headers.common["X-User-Organisation-Id"] = this.userOrganisationId;

    return config;
  }

  responseInterceptor(error: any) {
    // Show a snackbar warning the user from the error
    this.handleError(error.response);

    return error;
  }

  handleError(response: any) {
    let message = response.status + " : " + response.data;
    this.snacks.push(message);
  }
}
</script>

<style scoped>
.snackbar-text {
  display: inline-block;
  max-width: 400px;
  max-height: 200px;

  /** Hide scrollbar but can still scroll */
  overflow: scroll;
  scrollbar-width: none; /** Firefox */
  -ms-overflow-style: none; /** IE & Edge */
}

.snackbar-text::-webkit-scrollbar {
  display: none; /** Chrome, Safari & Opera */
}
</style>
