export class ExempleInfos {
  id: string;
  label: string;

  constructor(params: ExempleInfosDTO) {
    this.id = params.id;
    this.label = params.label;
  }
}

export interface ExempleInfosDTO {
  id: string;
  label: string;
}

export interface CreateExempleDTO {
  label: string;
}

export interface UpdateExempleDTO {
  id: string;
  label: string;
}