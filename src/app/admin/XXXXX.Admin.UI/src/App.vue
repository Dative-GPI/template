<template>
  <d-app class="d-extension">
    <extension-host-manager
      v-slot="{ languageCode, token, userApplicationId }"
    >
      <network-manager
        :language-code="languageCode"
        :token="token"
        :user-application-id="userApplicationId"
        @hook:mounted="loading = 1"
      >
        <translations-provider
          :language-code="languageCode"
          @hook:mounted="loading = 2"
        >
          <permissions-provider :user-application-id="userApplicationId" @hook:mounted="loading = 3">
            <layout @hook:mounted="loading = 4" />
          </permissions-provider>
        </translations-provider>
      </network-manager>
    </extension-host-manager>
  </d-app>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import ExtensionHostManager from "./views/roots/ExtensionHostManager.vue";
import NetworkManager from "./views/roots/NetworkManager.vue";
import TranslationsProvider from "./views/roots/TranslationsProvider.vue";
import PermissionsProvider from "./views/roots/PermissionsProvider.vue";
import Layout from "./Layout.vue";

@Component({
  components: {
    ExtensionHostManager,
    NetworkManager,
    TranslationsProvider,
    PermissionsProvider,
    Layout,
  }
})
export default class App extends Vue {
  // Properties
  // Data 

  loading = 0;

  // Computed Properties
  // Methods
  // Lifecycle
}
</script>