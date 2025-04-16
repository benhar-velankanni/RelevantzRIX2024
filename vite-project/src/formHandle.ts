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

export class PasswordInput {
    constructor(public value: string) {}

    getValue(): boolean {
        return this.value === "1234";
    }
}

export function processFormInput(input: TextInput | CheckboxInput | PasswordInput) {
    if (input instanceof TextInput) {
        console.log(`Name is: ${input.getValue()}`);
    } else if (input instanceof CheckboxInput) {
        console.log(`Terms and Condition: ${input.getValue()}`);
    } else if (input instanceof PasswordInput) {
        if (input.getValue()) {
            console.log(`Password is correct`);
            alert(`Welcome, ${input.getValue()}`);
        } else {
            console.log(`Password is not correct`);
            alert(`Password is not correct`);
        }
    }
}
