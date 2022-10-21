import { OrganisationTypeInfos } from "@/domain/models";

export interface IOrganisationTypeService {
    getMany(): Promise<OrganisationTypeInfos[]>;
}