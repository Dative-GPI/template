<template>
  <v-container fluid class="pa-0 ma-0 mt-2">
    <d-list-loader v-if="innerFetching || parentFetching" />
    <d-data-list
      v-else
      :height="height"
      :code="tableCode"
      :no-data-text="$tr('ui.tables.empty', 'No data yet')"
      :columns="columnUsers"
      :items="items"
      :item-class="itemClass"
      :disabled-tiles="disableTiles"
      :show-select="showSelect"
      :single-select="singleSelect"
      
      v-on="$listeners"
      @close="update"
      @click:row="itemClick"
    >
      <slot> </slot>
      <template v-for="(index, name) in $slots" v-slot:[name]>
        <slot :name="name" />
      </template>
      <template v-for="(index, name) in $scopedSlots" v-slot:[name]="data">
        <slot :name="name" v-bind="data"></slot>
      </template>
    </d-data-list>
  </v-container>
</template>

<script lang="ts">
import { DependencyContainer } from "tsyringe";
import { Component, Vue, Inject, InjectReactive, Prop } from "vue-property-decorator";

import { ORGANISATION, PROVIDER, SERVICES as S } from "@/config";
// import { ColumnUser } from "@/domain/models";
// import { IColumnUserService } from "@/interfaces";
import { onCollectionChanged } from "@/tools";

@Component({})
export default class List extends Vue {
  @InjectReactive(ORGANISATION)
  organisationId!: string;

  @Inject(PROVIDER)
  container!: DependencyContainer;

  @Prop({ required: true })
  tableCode!: string;

  @Prop({ required: true })
  items!: any[];

  @Prop({ required: false, default: 'calc(100vh - 144px)' })
  height!: string;

  @Prop({ required: false, default: '' })
  itemClass!: () => string;

  @Prop({ required: false, default: undefined })
  itemClick!: (() => any) | undefined;

  @Prop({ required: false, default: false })
  disableTiles!: boolean;

  @Prop({ required: false, default: false })
  showSelect!: boolean;

  @Prop({ required: false, default: false })
  singleSelect!: boolean;

  @Prop({ required : false, default: undefined })
  value!: any;

  @Prop({ required: false, default: false })
  parentFetching!: boolean;

  innerFetching = false;
  // columnUsers: ColumnUser[] = [];

  // async update(value: ColumnUser[]): Promise<void> {
  //   await this.columnUsersService.update(this.tableCode, { columns: value });
  // }

  mounted(): void {
    // this.columnUsersService.subscribe("reset", onCollectionChanged<ColumnUser, ColumnUser>(
    //   () => this.columnUsers,
    //   (u) => u.tableCode === this.tableCode,
    // ));

    this.fetch();
  }

  async fetch(): Promise<void> {
    this.innerFetching = true;

    try {
      // await this.columnUsersService.getMany(this.tableCode);
    }
    finally {
      this.innerFetching = false;
    }
  }

  // get columnUsersService(): IColumnUserService {
  //   return this.container.resolve<IColumnUserService>(S.COLUMNUSERSERVICE);
  // }
}

</script>