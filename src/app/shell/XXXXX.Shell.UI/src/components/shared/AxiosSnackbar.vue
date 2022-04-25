<template>
  <v-container class="ma-0 pa-0" fluid>
    <v-snackbar v-if="snacks.length > 0" :value="true" top right :timeout="-1">
      {{ snacks[snacks.length - 1] }} {{ more() }}
      <template v-slot:action="{ attrs }">
        <v-btn color="pink" text @click="close()" v-bind="attrs">
          {{ $tr('ui.common.close', 'Close') }}
        </v-btn>
      </template>
    </v-snackbar>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

@Component({})
export default class AxiosSnackbar extends Vue {
  @Prop({ required: true })
  queue!: Vue
  
  snacks: string[] = [];

  mounted(): void {
    this.queue.$on('push', (response: any) => {
      let message = this.buildSnack(response);

      if (this.snacks.filter(s => s === message).length === 0) {
        this.snacks.push(message);
      }
    });
  }

  more(): string {
    return this.snacks.length > 1 ? ` (${this.snacks.length - 1} ${this.$tr('ui.common.more', 'more')})` : '';
  }

  close(): void {
    this.snacks.pop();
  }

  buildSnack(response: any): string {
    let message = `${response.status} ${response.statusText} - ${this.$tr('ui.common.cannot', 'Cannot')} `;

    switch (response.config.method) {
      case "get": {
        message += this.$tr('ui.common.get', 'get');
        break;
      }
      case "post":
      case "put": {
        message += this.$tr('ui.common.create-or-update', 'create or update');
        break;
      }
      case "delete": {
        message += this.$tr('ui.common.remove', 'remove');
        break;
      }
    }

    switch (response.data) {
      case "AlertComments": {
       message += ` ${this.$tr('ui.common.alertComments', 'alert comments')}`;
       break;
      }
      case "Alerts": {
       message += ` ${this.$tr('ui.common.alerts', 'alerts')}`;
       break;
      }
      case "Articles": {
       message += ` ${this.$tr('ui.common.articles', 'articles')}`;
       break;
      }
      case "Categories": {
       message += ` ${this.$tr('ui.common.categories', 'categories')}`;
       break;
      }
      case "ChartBookmarks": {
       message += ` ${this.$tr('ui.common.chartBookmarks', 'chart bookmarks')}`;
       break;
      }
      case "ChartTemplates": {
       message += ` ${this.$tr('ui.common.chartTemplates', 'chart templates')}`;
       break;
      }
      case "ColumnUsers": {
       message += ` ${this.$tr('ui.common.columns', 'columns')}`;
       break;
      }
      case "Dashboards": {
       message += ` ${this.$tr('ui.common.dashboards', 'dashboards')}`;
       break;
      }
      case "DataDefinitions": {
       message += ` ${this.$tr('ui.common.dataDefinitions', 'data definitions')}`;
       break;
      }
      case "Devices": {
       message += ` ${this.$tr('ui.common.devices', 'devices')}`;
       break;
      }
      case "Families": {
       message += ` ${this.$tr('ui.common.families', 'families')}`;
       break;
      }
      case "Images": {
       message += ` ${this.$tr('ui.common.images', 'images')}`;
       break;
      }
      case "Languages": {
       message += ` ${this.$tr('ui.common.languages', 'languages')}`;
       break;
      }
      case "Locations": {
       message += ` ${this.$tr('ui.common.locations', 'locations')}`;
       break;
      }
      case "Manufacturers": {
       message += ` ${this.$tr('ui.common.manufacturers', 'manufacturers')}`;
       break;
      }
      case "MarketplaceRecipes": {
       message += ` ${this.$tr('ui.common.marketplaceRecipes', 'marketplace recipes')}`;
       break;
      }
      case "Models": {
       message += ` ${this.$tr('ui.common.models', 'models')}`;
       break;
      }
      case "Organisations": {
       message += ` ${this.$tr('ui.common.organisations', 'organisations')}`;
       break;
      }
      case "PageInformations": {
       message += ` ${this.$tr('ui.common.pageInformations', 'page informations')}`;
       break;
      }
      case "organisationTypePermissions":
      case "PermissionRoles": {
       message += ` ${this.$tr('ui.common.permissions', 'permissions')}`;
       break;
      }
      case "Programs": {
       message += ` ${this.$tr('ui.common.programs', 'programs')}`;
       break;
      }
      case "Recipes":
      case "RecipeDevices": {
       message += ` ${this.$tr('ui.common.recipes', 'recipes')}`;
       break;
      }
      case "Roles": {
       message += ` ${this.$tr('ui.common.roles', 'roles')}`;
       break;
      }
      case "Scenarios": {
       message += ` ${this.$tr('ui.common.scenarios', 'scenarios')}`;
       break;
      }
      case "Traductions": {
       message += ` ${this.$tr('ui.common.traductions', 'traductions')}`;
       break;
      }
      case "Users": {
       message += ` ${this.$tr('ui.common.users', 'users')}`;
       break;
      }
      case "Widgets": {
       message += ` ${this.$tr('ui.common.widgets', 'widgets')}`;
       break;
      }
      default: {
        message += ` ${this.$tr('ui.common.entity', 'entity')}`;
        break;
      }
    }
    return message;
  }
}
</script>