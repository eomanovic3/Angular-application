
export class Address{
    public addressId: number;
    public address1: string;
    public address2: string;
    public zipId: number;
    public userId: number;
    public isDeleted: boolean;

    public constructor(addressId?: number, address1?: string, address2?: string, zipId?: number, userId?: number, isDeleted?: boolean) {
        this.addressId = addressId || null;
        this.address1 = address1 || null;
        this.address2 = address2 || null;
        this.zipId = zipId || null;
        this.userId = userId || null;
        this.isDeleted = isDeleted || null;
    }
    
}
