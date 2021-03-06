<template>
  <div id="network-manager">
    <v-snackbar v-if="snacks.length > 0" :value="true" top right :timeout="-1">
      {{ snacks[snacks.length - 1] }}
      <template
        v-if="snacks.length > 1"
      >({{ snacks.length - 1 }} {{ $tr("ui.common.more", "more") }})</template>

      <template v-slot:action="{ attrs }">
        <v-btn color="pink" @click="close" v-bind="attrs" class="snackbar">
          {{
            $tr("ui.common.close", "Close")
          }}
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
  languageId!: string | null;

  @Prop({ required: false, default: () => null })
  languageCode!: string | null;

  @Prop({ required: false, default: () => null })
  userApplicationId!: string | null;

  @Prop({ required: false, default: false })
  disabled!: boolean;


  snacks: string[] = [];

  // Computed properties

  //Methods

  close(): void {
    this.snacks.pop();
  }

  mounted(): void {
    axios.interceptors.request.use(this.requestInterceptor);

    axios.interceptors.response.use(undefined, this.responseInterceptor);
  }

  requestInterceptor(config: AxiosRequestConfig) {
    if(this.token != null){
      // config.headers.Authorization = "Bearer " + this.token;
      config.headers.common['Authorization'] = `Bearer ${this.token}`;
    }

    if (this.languageId != null) {
      config.headers.common["X-Language-Id"] = this.languageId;
    }

    if (this.languageCode != null) {
      config.headers.common["X-Language-Code"] = this.languageCode;
    }

    if (this.userApplicationId != null) {
      config.headers.common["X-User-Application-Id"] = this.userApplicationId;
    }

    return config;
  }

  responseInterceptor(error: any) {
    if (!this.disabled) {
      if (error.response.status === 401) {
        // Remove user -> redirection to landing page
        this.$emit("logout");
      } else {
        // Show a snackbar warning the user from the error
        this.handleError(error.response);
      }
    }

    return error;
  }

  handleError(response: any) {
    let message = response.status + " : " + response.data;

    this.snacks.push(message);
  }
}
</script>

<style>
.snackbar {
  position: absolute;
  right: 4px;
}
</style>