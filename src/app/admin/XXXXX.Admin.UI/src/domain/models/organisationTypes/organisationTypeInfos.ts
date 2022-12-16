export class OrganisationTypeInfos {
    id: string;
    code: string;
    label: string;
    description: string;
    nbOrganisations: number;

    constructor(params: OrganisationTypeInfosDTO) {
        this.id = params.id;
        this.code = params.code;
        this.label = params.label;
        this.description = params.description;
        this.nbOrganisations = params.nbOrganisations;
    }
}

export interface OrganisationTypeInfosDTO {
    id: string;
    code: string;
    label: string;
    description: string;
    nbOrganisations: number;
}