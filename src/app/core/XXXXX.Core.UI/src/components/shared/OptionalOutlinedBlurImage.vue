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
  <d-outlined-img v-else v-bind="$attrs" v-on="$listeners" :src="undefined" />
</template>

<script lang="ts">
import { Component, InjectReactive, Prop, Vue } from "vue-property-decorator";
import { IMAGE_FOUNDATION_RAW_URL, IMAGE_RAW_URL, TOKEN } from "@/config";

@Component({})
export default class OptionalOutlinedBlurImage extends Vue {
  // Properties

  @InjectReactive(TOKEN)
  token!: string;

  @Prop({ required: false, default: () => null })
  imageId!: string | null;

  @Prop({ required: false, default: () => null })
  imageWidth!: number | null;

  @Prop({ required: false, default: () => null })
  imageHeight!: number | null;

  @Prop({ required: false, default: () => null })
  imageBlurHash!: string | null;

  @Prop({ required: false, default: false, type: Boolean })
  isFoundationImage!: boolean;

  // Data
  // Computed Properties

  get imageUrl() {
    return this.imageId
      ? this.isFoundationImage
        ? IMAGE_FOUNDATION_RAW_URL(this.imageId, this.token)
        : IMAGE_RAW_URL(this.imageId)
      : "";
  }

  // Methods
}
</script>
