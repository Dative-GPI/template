<template>
  <span class="text-h1"> {{ $tr(codeLabel, defaultLabel) }} </span>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component({})
export default class SimpleTitle extends Vue {
  @Prop({ required: true })
  codeLabel!: string;

  @Prop({ required: true })
  defaultLabel!: string;
}
</script>
