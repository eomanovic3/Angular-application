

export class Zip {
    public zipId: number;
    public zipCode: string;
    public cityId: number;


    public constructor(zipId?: number, zipCode?: string, cityId?: number) {
        this.zipId = zipId || null;
        this.zipCode = zipCode || null;
        this.cityId = cityId || null;
    }
}

     
