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

      <d-img
        v-if="editMode && canAdd"
        :editable="true"
        :width="120"
        :height="120"
        resize
        resize-size="600"
        src="a"
      >
        <template #actions="{ resize }">
          <div class="add-image-btn" v-if="editMode && canAdd">
            <d-btn-file
              @input="(data) => addImage(data, resize)"
              accept="image/*"
              class="d-btn-edit-img"
            />
            <v-icon>mdi-plus-circle-outline</v-icon>
          </div>
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

  // @Prop({ required: false, default: 0 })
  // minItems!: number;

  @Prop({ required: false, default: -1 })
  maxItems!: number;

  // Data
  // Computed Properties

  get canAdd() {
    return this.maxItems < 0 || this.items.length < this.maxItems;
  }

  // Methods

  getUrl(image: EditableImageDTO) {
    return image.imageId ? IMAGE_RAW_URL(image.imageId) : undefined;
  }

  getValue(image: EditableImageDTO) {
    if (image.image) return image.image;
    return undefined;
  }

  async addImage(
    data: string,
    resizeFunction: (data: string) => Promise<string> = (data: string) =>
      new Promise((res) => res(data))
  ) {
    data = await resizeFunction(data);

    const [valueType, value] = data.split(",");
    this.$emit("change", [
      ...this.items,
      {
        image: value,
        imageType: valueType,
      },
    ]);
  }

  updateImage(index: number, data: string) {
    this.$emit(
      "change",
      this.items.map((img, i) => {
        if (i === index) {
          return {
            image: data,
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
.add-image-btn {
  width: 120px;
  height: 120px;
}

.add-image-btn .d-btn-edit-img {
  opacity: 0;
}

.add-image-btn > .v-icon {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  pointer-events: none;
}
</style>
