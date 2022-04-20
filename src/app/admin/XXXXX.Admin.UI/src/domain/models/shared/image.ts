
export class Image {
    imageId: string;
    imageBlurHash: string;
    imageHeight: number;
    imageWidth: number;

    constructor(params: ImageDTO){
        this.imageId = params.imageId;
        this.imageBlurHash = params.imageBlurHash;
        this.imageHeight = params.imageHeight;
        this.imageWidth = params.imageWidth;
    }
}

export interface ImageDTO {
    imageId: string;
    imageBlurHash: string;
    imageHeight: number;
    imageWidth: number;
}