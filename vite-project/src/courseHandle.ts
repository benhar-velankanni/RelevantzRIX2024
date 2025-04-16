export class Cotitle{
    constructor(public cotitle: string) {} 
    getcTitle(): string {
        return this.cotitle;
    }
}
export class CoInstructor{
    constructor(public coinstructor: string) {} 
    getcInstructor(): string {
        return this.coinstructor;
    }
}

export class Coduration{
    constructor(public coduration: number) {} 
    getcDuration(): number {
        return this.coduration;
    }
}

export class CoCheckbox{
    constructor(public cocheckbox: boolean) {} 
    getCheckbox(): boolean {
        return this.cocheckbox;
    }
}

export function courseFromInput(input: Cotitle | CoInstructor | Coduration | CoCheckbox): void {
    if (input instanceof Cotitle) {
        console.log(`Title is: ${input.getcTitle()}`);
    } else if (input instanceof CoInstructor) {
        console.log(`Instructor is: ${input.getcInstructor()}`);
    } else if (input instanceof Coduration) {
        console.log(`Duration is: ${input.getcDuration()}`);
    } else if (input instanceof CoCheckbox) {
        console.log(`Course Instock: ${input.getCheckbox()}`);
    }
}
