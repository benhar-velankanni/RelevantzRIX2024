export class TextInput{
    constructor(public value: string){}
    getValue(){
        return this.value;
    }
}
export class CheckboxInput{
    constructor(public value: boolean){}
    getValue(){
        return this.value;
    }
}

export function processForm(input: TextInput | CheckboxInput){
    if(input instanceof TextInput){
        console.log(`Text Input: ${input.getValue()}`);
    }
    else if(input instanceof CheckboxInput){
        console.log(`Checkbox Input: ${input.getValue()}`);
    }
}