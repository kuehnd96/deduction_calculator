import { Dependent } from './dependent'

export class Employee {
    firstName?: string;
    lastName?: string;
    dependents?: Dependent[] | undefined;

    constructor() {
    }
}