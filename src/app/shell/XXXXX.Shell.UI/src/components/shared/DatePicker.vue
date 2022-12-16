<template>
  <v-row no-gutters>
    <d-select v-if="preset"
      :items="presets"
      :value="selectedPreset"
      class="date-picker-width text-h6 mr-2"
      item-text="label"
      item-value="id"

      @input="onPreset"
    />
    <v-menu
      offset-y
      bottom
      :disabled="preset && selectedPreset.id !== 6"
      :close-on-content-click="false"
    >
      <template #activator="{ on }">
        <d-text-field
          class="date-picker-width text-h6 mr-2"
          v-on="on"
          readonly
          :disabled="preset && selectedPreset.id !== 6"
          :value="formatDate(value[0])"
          :prefix="prefixes[0]"
          @input="onPreInput"
        />
      </template>
      <v-date-picker
        range
        :value="dateISOString"
        @input="onPreInput"
      />
    </v-menu>
    <v-menu
      v-if="range"
      offset-y
      bottom
      :disabled="preset && selectedPreset.id !== 6"
      :close-on-content-click="false"
    >
      <template #activator="{ on }">
        <d-text-field
          class="date-picker-width text-h6"
          v-on="on"
          readonly
          :disabled="preset && selectedPreset.id !== 6"
          :value="formatDate(value[1])"
          :prefix="prefixes[1]"
          @input="onPreInput"
        />
      </template>
      <v-date-picker
        range
        :value="dateISOString"
        @input="onPreInput"
      />
    </v-menu>
  </v-row>
</template>

<script lang="ts">
import { DateTools } from "@/tools/dateTools";
import { Component, Vue, Prop } from "vue-property-decorator";

@Component({
  methods: {
    formatDate: DateTools.formatDate,
  }
})
export default class DDatePicker extends Vue {
  @Prop({ required: false, default: false })
  range!: boolean;

  @Prop({ required: false, default: false })
  preset!: boolean;

  @Prop({ required: true })
  value!: Date[];

  get dateISOString() {
    return this.value.map(v => DateTools.formatISODate(v));
  }

  @Prop({ required: false, default: ["", ""] })
  prefixes!: string[];

  presets: { id: number, label: string}[] = [
    { id: 0, label: this.$tr('ui.common.this-week', 'This week') },
    { id: 1, label: this.$tr('ui.common.this-month', 'This month') },
    { id: 2, label: this.$tr('ui.common.this-year', 'This year') },
    { id: 3, label: this.$tr('ui.common.last-7-days', 'Last 7 days') },
    { id: 4, label: this.$tr('ui.common.last-30-days', 'Last 30 days') },
    { id: 5, label: this.$tr('ui.common.last-365-days', 'Last 365 days') },
    { id: 6, label: this.$tr('ui.common.select-dates', 'Select dates') },
  ];
  selectedPreset: { id: number, label: string} = this.presets[0];

  onPreset(value: number) {
    this.selectedPreset = this.presets.filter(p => p.id === value)[0];
    switch (value) {
      case 0: {
        this.onInput([
          DateTools.startOfWeek(new Date()),
          DateTools.subDays(new Date(), -1),
        ]);
        return;
      }
      case 1: {
        this.onInput([
          DateTools.startOfMonth(new Date()),
          DateTools.subDays(new Date(), -1),
        ]);
        return;
      }
      case 2: {
        this.onInput([
          DateTools.startOfYear(new Date()),
          DateTools.subDays(new Date(), -1),
        ]);
        return;
      }
      case 3: {
        this.onInput([
          DateTools.subDays(new Date(), 7),
          DateTools.subDays(new Date(), -1),
        ]);
        return;
      }
      case 4: {
        this.onInput([
          DateTools.subDays(new Date(), 30),
          DateTools.subDays(new Date(), -1),
        ]);
        return;
      }
      case 5: {
        this.onInput([
          DateTools.subDays(new Date(), 365),
          DateTools.subDays(new Date(), -1),
        ]);
        return;
      }
    }
  }

  onPreInput(value: string[]): void {
    this.onInput(value.map(v => DateTools.parseDate(v)));
  }

  onInput(value: Date[]): void {
    if (value.length > 1) {
      if (DateTools.isAfter(value[0], value[1])) {
        value = [value[1], value[0]];
      }
    }
    this.$emit('input', value);
  }
}
</script>

<style scoped>
.date-picker-width {
  max-width: 180px;
  max-height: 28px !important;
}

.date-picker-width * {
  margin-top: 0px !important;
}
</style>