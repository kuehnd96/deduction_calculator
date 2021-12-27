import { Dependent } from './dependent'

export class Employee {
    firstName?: string;
    lastName?: string;
    dependents?: Dependent[] | undefined;

    constructor() {
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;

        if (this.dependents != undefined) {
            for (var i=0; i<this.dependents.length; i++) {
                data["dependents"] += this.dependents[i].toJSON();
            }
        }
        return data;
    }
}