export class Dependent {
    firstName?: string;
    lastName?: string;

    constructor() {
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;

        return data;
    }
}
