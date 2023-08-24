<template>
  <d-app class="d-extension">
    <extension-host-manager
      v-slot="{ languageCode, token, userOrganisationId }"
    >
      <network-manager
        :language-code="languageCode"
        :token="token"
        :user-organisation-id="userOrganisationId"
      >
        <translations-provider
          :language-code="languageCode"
        >
          <permissions-provider :user-organisation-id="userOrganisationId">
            <layout />
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
  },
})
export default class App extends Vue {
  // Properties
  // Data
  // Computed Properties
  // Methods
  // Lifecycle
}
</script>
