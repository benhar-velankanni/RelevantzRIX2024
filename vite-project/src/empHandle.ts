export class EName{ 
    constructor(public ename: string) {} 
    getEName(): string {
        return this.ename;
    }
} 
export class EPosition{
    constructor(public eposition: string) {} 
    getEPosition(): string {
        return this.eposition;
    }
}  
export class ESalary{
    constructor(public esalary: number) {}
    getESalary(): number {
        return this.esalary;
    }
}

export class ECheckbox{
    constructor(public echeckbox: boolean) {} 
    getCheckbox(): boolean {
        return this.echeckbox;
    }
}

export function empFromInput(input: EName | EPosition | ESalary | ECheckbox) {
    if (input instanceof EName) {
        console.log(`Name is: ${input.getEName()}`);
    } else if (input instanceof EPosition) {
        console.log(`Position is: ${input.getEPosition()}`);
    } else if (input instanceof ESalary) {
        console.log(`Salary is: ${input.getESalary()}`);
    } else if (input instanceof ECheckbox) {
        console.log(`Employee Full_Time: ${input.getCheckbox()}`);
    }
}
