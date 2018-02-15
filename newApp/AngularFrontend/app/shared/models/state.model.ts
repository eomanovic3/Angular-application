export class State {
    public id: number;
    public stateName: string;

    public constructor(_id?: number, _stateName?: string) {
        this.id = _id || null;
        this.stateName = _stateName || null;
    }
}