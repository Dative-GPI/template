<template>
  <d-outlined-blur-img
    v-if="imageId"
    v-bind="$attrs"
    v-on="$listeners"
    :src="imageUrl"
    :imageWidth="imageWidth"
    :imageHeight="imageHeight"
    :imageBlurHash="imageBlurHash"
  />
  <d-outlined-img
    v-else
    v-bind="$attrs"
    v-on="$listeners"
    :src="undefined"
  />
</template>

<script lang="ts">
import {
  Component,
  Prop,
  Vue,
} from "vue-property-decorator";

import { Image } from "@/domain/models";
import { IMAGE_RAW_URL } from "@/config";

@Component({})
export default class OptionalBlurImage extends Vue {
  // Properties

  @Prop({ required: false, default: () => null })
  imageId!: string | null;

  @Prop({ required: false, default: () => null })
  imageWidth!: number | null;

  @Prop({ required: false, default: () => null })
  imageHeight!: number | null;

  @Prop({ required: false, default: () => null })
  imageBlurHash!: string | null;

  // Data
  // Computed Properties

  get imageUrl() {
    return this.imageId ? IMAGE_RAW_URL(this.imageId) : ''
  }

  // Methods
}
</script>
