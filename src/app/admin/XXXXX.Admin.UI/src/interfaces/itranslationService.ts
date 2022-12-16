import { Translation } from "@/domain/models";

export interface ITranslationService {
    getMany(): Promise<Translation[]>;
}