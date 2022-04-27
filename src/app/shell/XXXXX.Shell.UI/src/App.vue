<template>
  <d-app class="d-extension">
    <extension-host-manager
      v-slot="{ languageId, languageCode, token, userApplicationId }"
    >
      <div style="height: 500px; background-color: red" />
      <network-manager
        v-show="show"
        :disabled="!userId"
        :language-id="languageId"
        :language-code="languageCode"
        :token="token"
        :user-application-id="userApplicationId"
        @logout="userId = null"
        @hook:mounted="loading = 1"
      >
        <!-- <translations-provider
          :language-id="languageId"
          :language-code="languageCode"
          @hook:mounted="loading = 2"
        > -->
          <!-- <permissions-provider :user-application-id="userApplicationId" @hook:mounted="loading = 3"> -->
            <layout @hook:mounted="loading = 2" />
          <!-- </permissions-provider> -->
        <!-- </translations-provider> -->
      </network-manager>

      <div v-if="!show" class="progress">
        <v-progress-linear
          color="light-green darken-4"
          height="10"
          :value="(state / 2) * 100"
          striped
        ></v-progress-linear>
      </div>
    </extension-host-manager>
  </d-app>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import ExtensionHostManager from "./views/roots/ExtensionHostManager.vue";
import NetworkManager from "./views/roots/NetworkManager.vue";
// import ApplicationProvider from "./views/roots/ApplicationProvider.vue";
// import LanguageProvider from "./views/roots/LanguageProvider.vue";
import TranslationsProvider from "./views/roots/TranslationsProvider.vue";
// import UserProvider from "./views/roots/UserProvider.vue";
// import UserApplicationProvider from "./views/roots/UserApplicationProvider.vue";
import PermissionsProvider from "./views/roots/PermissionsProvider.vue";
// import RoutesProvider from "./views/roots/RoutesProvider.vue";
import Layout from "./Layout.vue";

@Component({
  components: {
    ExtensionHostManager,
    NetworkManager,
    // ApplicationProvider,
    // LanguageProvider,
    TranslationsProvider,
    // UserProvider,
    // UserApplicationProvider,
    PermissionsProvider,
    // RoutesProvider,
    Layout,
  }
})
export default class App extends Vue {
  userId = null;
  languageId = null;

  loading = 0;
  state = 0;
  show = false;
  askShow = false;

  timer = 0;

  mounted() {
    this.timer = setInterval(() => {
      if (this.state <= this.loading) this.state++;
      else if (this.askShow) this.show = true;

      if (this.state == 2) {
        clearInterval(this.timer);
        setTimeout(() => (this.show = true), 300);
      }
    }, 100);
  }
}
</script>

<style scoped>
.progress {
  position: absolute;
  width: 50vw;
  top: 50%;
  left: 50%;
  transform: translate(-50%, 50%);
}
</style>