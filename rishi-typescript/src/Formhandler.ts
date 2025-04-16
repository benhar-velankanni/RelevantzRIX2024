export class TextInput {
    constructor(public value: string) {}

    getValue(): string {
        return this.value;
    }
}

export class CheckboxInput {
    constructor(public checked: boolean) {}

    getValue(): boolean {
        return this.checked;
    }
}

export function processFormInput(input: TextInput | CheckboxInput): void {
    if (input instanceof TextInput) {
        console.log(`TextInput: ${input.getValue()}`);
    } else if (input instanceof CheckboxInput) {
        console.log(`CheckboxInput: ${input.getValue()}`);
    }
}
