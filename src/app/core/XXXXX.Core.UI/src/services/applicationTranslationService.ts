import axios from "axios";

import { IExtensionCommunicationService, IApplicationTranslationService } from "@/interfaces";
import { buildURL, NotifyService } from "@/tools";
import { inject, injectable } from "tsyringe";

import { APPLICATION_TRANSLATIONS_URL } from "@/config/urls";
import {
  ApplicationTranslation,
  ApplicationTranslationDTO,
  ApplicationTranslationSelector,
} from "@/domain/models";
import { SERVICES as S } from "@/config";

@injectable()
export class ApplicationTranslationService extends NotifyService<ApplicationTranslation, ApplicationTranslation>
  implements IApplicationTranslationService {

  type: string = "translations";

  constructor(
    @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async getMany(payload: ApplicationTranslationSelector): Promise<ApplicationTranslation[]> {
    const response = await axios.get(buildURL(APPLICATION_TRANSLATIONS_URL, payload));

    const dto: ApplicationTranslationDTO[] = response.data;
    const translations = dto.map((t) => new ApplicationTranslation(t));
    
    this.notify({
      action: "reset",
      type: this.type,
      items: translations.slice(),
    });

    return translations;
  }
}
