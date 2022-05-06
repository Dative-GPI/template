import { container } from "tsyringe";

import { SERVICES as S } from "@/config"
import { IExtensionCommunicationService, IExempleService } from "@/interfaces";
import { ExtensionCommunicationService, ExempleService } from "@/services";

container.registerSingleton<IExempleService>(S.EXEMPLESERVICE, ExempleService);
container.registerSingleton<IExtensionCommunicationService>(S.EXTENSIONCOMMUNICATIONSERVICE, ExtensionCommunicationService);

export { container };