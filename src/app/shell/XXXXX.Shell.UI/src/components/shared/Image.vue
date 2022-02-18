<template>
  <div>
    <!-- <d-circle
      :height="addPixels(height, 10)"
      :width="addPixels(width, 10)"
      class="blurhash-container"
    />
    <v-img
      v-if="!fetching"
      v-bind="$attrs"
      :height="height"
      :width="width"
      :class="roundedCircle ? 'rounded-circle image-container': 'image-container'"
      :src="'data:image/png;base64, ' + base64"
    />
    <blur-hash-canvas
      v-bind="$attrs"
      :height="height"
      :width="width"
      :class="roundedCircle ? 'rounded-circle blurhash-container': 'blurhash-container'"
      :hash="image.blurHash"
    /> -->
  </div>
</template>

<script lang="ts">
// import { DependencyContainer } from "tsyringe";
// import { Component, Inject, InjectReactive, Prop, Vue } from "vue-property-decorator";
// import { BlurHashCanvas } from "vue-blurhash";

// import { ORGANISATION, PROVIDER, SERVICES as S } from "@/config";

// @Component({
//   inheritAttrs: false,
//   components: {
//     BlurHashCanvas
//   }
// })
// export default class DImage extends Vue {
//   @InjectReactive(ORGANISATION)
//   organisationId!: string;

//   @Inject(PROVIDER)
//   container!: DependencyContainer;

//   @Prop({ required: true })
//   image!: Image;

//   @Prop({ required: true })
//   width!: string;

//   @Prop({ required: true })
//   height!: string;

//   @Prop({ required: false, default: false })
//   roundedCircle!: boolean;

//   base64 = '';
//   fetching = true;

//   addPixels(size: string, increment: number): string {
//     let value = parseInt(size.match(/[0-9]+/g)![0]);
//     value += increment;
//     return `${value}px`;
//   }

//   mounted(): void {
//     this.fetch();
//   }

//   async fetch(): Promise<void> {
//     this.fetching = true;

//     try {
//       this.base64 = await this.imageService.get(this.organisationId, this.image.uri);
//     }
//     finally {
//       this.fetching = false;
//     }
//   }

//   get imageService(): IImageService {
//     return this.container.resolve<IImageService>(S.IMAGESERVICE);
//   }
// }
</script>

<style scoped>
.blurhash-container::v-deep {
  position: absolute;
  z-index: 1 !important;
}

.image-container::v-deep {
  position: absolute;
  z-index: 5 !important;
}

.rounded-circle::v-deep {
  border-radius: 50% !important;
}
</style>