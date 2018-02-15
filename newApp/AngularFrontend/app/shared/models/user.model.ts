

export class User {
    public userId: number;
    public firstName:string;
    public lastName: string;
    public userName: string;
    public isDeleted: boolean;
    

    public constructor(userId?: number, firstName?: string, lastName?: string, userName?: string, isDeleted?: boolean) {
        this.userId = userId || null;
        this.firstName = firstName || null;
        this.lastName = lastName || null;
        this.userName = userName || null;
        this.isDeleted = isDeleted || null;
    }
}
