import axios from "axios";
import { FOUNDATION_ORGANISATION_TYPES_URL } from "@/config";
import {
  OrganisationTypeInfos,
  OrganisationTypeInfosDTO,
} from "@/domain/models";
import {
  IOrganisationTypeService,
} from "@/interfaces";
import _, { DebouncedFunc } from "lodash";

export class OrganisationTypeService implements IOrganisationTypeService {
  type: string = "OrganisationTypeService";
  debouncedGetMany: DebouncedFunc<() => Promise<OrganisationTypeInfos[]>>;

  constructor() {
    this.debouncedGetMany = _.debounce(this.getManyRequest, 500, { leading: true });
  }

  async getMany(): Promise<OrganisationTypeInfos[]> {
    const promise = this.debouncedGetMany();

    if (!promise) throw new Error();

    return promise.then(l => l.slice());
  }

  async getManyRequest(): Promise<OrganisationTypeInfos[]> {
    return axios.get(FOUNDATION_ORGANISATION_TYPES_URL)
      .then(response => {
        const dtos: OrganisationTypeInfosDTO[] = response.data;
        return dtos.map(d => new OrganisationTypeInfos(d));
      });
  }
}
