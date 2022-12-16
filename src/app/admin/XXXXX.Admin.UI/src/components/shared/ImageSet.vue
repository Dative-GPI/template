<template>
  <div>
    <v-row no-gutters>
      <d-blur-img
        v-for="(img, index) in items"
        :key="index"
        :src="getUrl(img)"
        :value="getValue(img)"
        :image-width="img.imageWidth"
        :image-height="img.imageHeight"
        :image-blur-hash="img.imageBlurHash"
        class="mr-4"
        :width="120"
        :height="120"
        :editable="editMode"
        @input="updateImage(index, $event)"
        @remove="removeImage(index)"
      />

      <d-img v-if="editMode" :editable="true" :width="120" :height="120">
        <template #actions>
          <d-btn-file icon="mdi-plus" @input="addImage" accept="image/*" class="d-btn-edit-img" />
        </template>
      </d-img>
    </v-row>
  </div>
</template>

<script lang="ts">
import _ from "lodash";
import { Component, Prop, Vue } from "vue-property-decorator";

import { IMAGE_RAW_URL } from "@/config";
import { EditableImageDTO, UpdateImageDTO } from "@/domain/models";

@Component({})
export default class ImageSet extends Vue {
  // Properties

  @Prop({ required: false })
  items!: EditableImageDTO[];

  @Prop({ required: false, default: false })
  editMode!: boolean;

  // Data
  // Computed Properties
  // Methods

  getUrl(image: EditableImageDTO) {
    return image.imageId ? IMAGE_RAW_URL(image.imageId) : undefined;
  }

  getValue(image: EditableImageDTO) {
    if (image.image) return image.image;
    return undefined;
  }

  addImage(data: string) {
    const [valueType, value] = data.split(",");
    this.$emit("change", [
      ...this.items,
      {
        image: value,
        imageType: valueType
      },
    ]);
  }

  updateImage(index: number, data: string) {
    this.$emit(
      "change",
      this.items.map((img, i) => {
        if (i === index) {
          return {
            image: data
          };
        }
        return img;
      })
    );
  }

  removeImage(index: number) {
    this.$emit(
      "change",
      this.items.filter((img, i) => i !== index)
    );
  }
}
</script>

<style scoped>
.d-btn-edit-img {
  opacity: 0.9;
}
</style>
