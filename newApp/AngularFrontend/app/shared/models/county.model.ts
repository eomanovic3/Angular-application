import { State } from "./state.model";

export class County {
    public id: number;
    public name: string;
    public state: State;

    public constructor(_id?: number, _name?: string, _state?: State) {
        this.id = _id || null;
        this.name = _name || null;
        this.state = _state || null;
    }
    
    
}
