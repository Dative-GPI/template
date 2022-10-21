export class Translation {
    code: string;
    value: string;

    constructor(params: TranslationDTO) {
        this.code = params.code;
        this.value = params.value;
    }
}

export interface TranslationDTO {
    code: string;
    value: string;
}