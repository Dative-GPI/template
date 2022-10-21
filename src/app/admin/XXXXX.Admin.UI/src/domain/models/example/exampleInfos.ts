export class ExampleInfos {
  id: string;
  label: string;

  constructor(params: ExampleInfosDTO) {
    this.id = params.id;
    this.label = params.label;
  }
}

export interface ExampleInfosDTO {
  id: string;
  label: string;
}

export interface CreateExampleDTO {
  label: string;
}

export interface UpdateExampleDTO {
  label: string;
}