
export class Image {
    imageId: string;
    imageWidth: number;
    imageHeight: number;
    imageBlurHash: string;

    constructor(params: ImageDTO){
        this.imageId = params.id;
        this.imageWidth = params.width;
        this.imageHeight = params.height;
        this.imageBlurHash = params.blurHash;
    }
}

export interface ImageDTO {
    id: string;
    width: number;
    height: number;
    blurHash: string;
}

export interface EditableImageDTO {
    imageId?: string;
    imageWidth?: number;
    imageHeight?: number;
    imageBlurHash?: string;
    image?: string;
}

export interface UpdateImageDTO {
    imageId?: string;
    image?: string;
}