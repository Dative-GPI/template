export class ExempleDetails {
  id: string;
  label: string;

  constructor(params: ExempleDetailsDTO) {
    this.id = params.id;
    this.label = params.label;
  }
}

export interface ExempleDetailsDTO {
  id: string;
  label: string;
}