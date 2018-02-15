import { County } from "./county.model";

export class City {
    public id: number;
    public name: string;
    public county: County;

    public constructor(_id?: number, _name?: string, _county?: County) {
        this.id = _id || null;
        this.name = _name || null;
        this.county = _county || null;
    }

}