import { IExtensionCommunicationService } from "@/interfaces";
import { buildURL, delay, NotifyService } from "@/tools";
import { inject, injectable } from "tsyringe";
import { SERVICES as S } from "@/config";
import { CreateExampleDTO, ExampleDetails, ExampleDetailsDTO, ExampleInfos, UpdateExampleDTO } from "@/domain/models";
import { IExampleService } from "@/interfaces/iexampleService";
import { uniqueId } from "lodash";

@injectable()
export class ExampleService extends NotifyService<ExampleInfos, ExampleDetails>
  implements IExampleService {

    examples: ExampleDetailsDTO[] = [
      {
        id: "1dda5a31-0ad1-4f5a-9589-caf09a0e8477",
        label: "Example n°1"
      },
      {
        id: "e97f7082-9760-4210-b1db-3b8448b40b65",
        label: "Example n°2"
      }
    ];

  type: string = "examples";

  constructor(
    @inject(S.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async get(organisationId: string, exampleId: string): Promise<ExampleDetails> {
    await delay(500);
    var example = this.examples.find(e => e.id == exampleId);

    if (!example) throw new Error("Example not found");

    return new ExampleDetails(example);
  }

  async getMany(organisationId: string): Promise<ExampleInfos[]> {
    await delay(500);
    var results = this.examples.map(e => new ExampleInfos(e));

    this.notifyAll({
      action: "reset",
      items: results,
      type: this.type
    });

    return results;
  }

  async create(organisationId: string, payload: CreateExampleDTO): Promise<ExampleDetails> {
    await delay(500);

    const dto: ExampleDetailsDTO = {
      id: uniqueId(payload.label),
      label: payload.label
    };

    this.examples.push(dto);
    const example = new ExampleDetails(dto);

    this.notifyAll({
      action: "add",
      type: this.type,
      items: [example],
    });

    return example;
  }

  async update(organisationId: string, exampleId: string, payload: UpdateExampleDTO): Promise<ExampleDetails> {
    await delay(500);
    var example = this.examples.find(e => e.id == exampleId);

    if (!example) throw new Error("Example not found");

    example.label = payload.label;
    const result = new ExampleDetails(example);

    this.notifyAll({
      action: "update",
      item: result,
      type: this.type
    });

    return result;
  }

  async remove(organisationId: string, exampleId: string): Promise<void> {
    await delay(500);
    var exampleIndex = this.examples.findIndex(e => e.id == exampleId);

    if (exampleIndex == -1) throw new Error("Example not found");

    this.examples.splice(exampleIndex, 1);
  }
}
