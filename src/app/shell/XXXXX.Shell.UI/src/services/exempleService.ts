import { IExtensionCommunicationService } from "@/interfaces";
import { buildURL, NotifyService } from "@/tools";
import { inject, injectable } from "tsyringe";
import { SERVICES as S } from "@/config";
import { CreateExempleDTO, ExempleDetails, ExempleDetailsDTO, ExempleInfos, UpdateExempleDTO } from "@/domain/models";
import { IExempleService } from "@/interfaces/iexempleService";
import { uniqueId } from "lodash";

@injectable()
export class ExempleService extends NotifyService<ExempleInfos, ExempleDetails>
  implements IExempleService {

  type: string = "exemples";

  constructor(
    @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async get(organisationId: string, exempleId: string): Promise<ExempleDetails> {
    throw new Error("Method not implemented.");
  }

  async getMany(
    organisationId: string
  ): Promise<ExempleInfos[]> {
    return [{
      id:"default",
      label: "default exemple"
    }];
  }

  async create(
    organisationId: string,
    payload: CreateExempleDTO
  ): Promise<ExempleDetails> {
    const dto: ExempleDetailsDTO = {
      id: uniqueId(payload.label),
      label: payload.label
    };

    const exemple = new ExempleDetails(dto);
    this.notifyAll({
      action: "add",
      type: this.type,
      items: [exemple],
    });
    return exemple;
  }

  async update(
    organisationId: string,
    exempleId: string,
    payload: UpdateExempleDTO
  ): Promise<ExempleDetails> {
    throw new Error("Method not implemented.");
  }

  async remove(organisationId: string, exempleId: string): Promise<void> {
    throw new Error("Method not implemented.");
  }
}
