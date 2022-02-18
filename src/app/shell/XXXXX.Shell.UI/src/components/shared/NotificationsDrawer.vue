<template>
  <v-container fluid class="ma-0 pa-2">
    <drawer-loader v-if="fetching" />
    <template v-else>
      <v-row no-gutters class="ml-10 mt-1 mb-6">
        <span class="text-h2">
          {{ $tr("ui.common.notifications", "Notifications") }}
        </span>
      </v-row>
    </template>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";


@Component({})
export default class NotificationsDrawer extends Vue {

  fetching = false;
}
</script>