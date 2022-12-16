import { ApplicationTranslation, Translation } from "@/domain/models";

export class TranslationsManager {
  private static _instance: TranslationsManager;

  public static get instance(): TranslationsManager {
    return this._instance || (this._instance = new this());
  }

  private translations: Translation[];

  private constructor() {
    this.translations = [];
  }

  public set(translations: ApplicationTranslation[]): void {
    this.translations = translations.map(t => ({ id: "", value: t.value, code: t.translationCode }));
  }

  public get(code: string): string | undefined {
    return this.translations.find(t => t.code === code)?.value;
  }
}