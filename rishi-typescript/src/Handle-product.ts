// //create form handler for product form with name, price, inStock link with my form.html

export class TextInputP {
        constructor(private value: string) {}
    
        getValue(): string {
            return this.value;
        }
    }
    
    export class CheckboxInputP {
        constructor(private value: boolean) {}
    
        getValue(): boolean {
            return this.value;
        }
    }
    export function processProductFormInput(input: TextInputP | CheckboxInputP): void {
        if (input instanceof TextInputP) {
            console.log(`TextInput: ${input.getValue()}`);
        } else if (input instanceof CheckboxInputP) {
            console.log(`CheckboxInput: ${input.getValue()}`);  
        }
    }
