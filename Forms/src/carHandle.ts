export class Make{
    constructor(public make: string) {}
 
    getMake(): string {
        return this.make;
    }
}
export class Model{
    constructor(public model: string) {}
 
    getModel(): string {
        return this.model;
    }
}
export class Year{
    constructor(public year: number) {}
 
    getYear(): number {
        return this.year;
    }
}    
 
export class CCheckbox{
    constructor(public ccheckbox: boolean) {}
 
    getCheckbox(): boolean {
        return this.ccheckbox;
    }
}
 
export function carFromInput(input: Make | Model | Year | CCheckbox) {
    if (input instanceof Make) {
        console.log(`Make is: ${input.getMake()}`);
    } else if (input instanceof Model) {
        console.log(`Model is: ${input.getModel()}`);
    } else if (input instanceof Year) {
        console.log(`Year is: ${input.getYear()}`);
    } else if (input instanceof CCheckbox) {
        console.log(`Car Running: ${input.getCheckbox()}`);
    }
}
 
 