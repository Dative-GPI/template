export class ExampleDetails {
  id: string;
  label: string;

  constructor(params: ExampleDetailsDTO) {
    this.id = params.id;
    this.label = params.label;
  }
}

export interface ExampleDetailsDTO {
  id: string;
  label: string;
}