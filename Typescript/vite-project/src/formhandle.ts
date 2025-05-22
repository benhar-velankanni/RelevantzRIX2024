export class Textinput{
    constructor(public value:string){}
    getValue(){
        return this.value;
    }
}
export class Checkbox{
    constructor(public checked:boolean){}
    getValue(){
        return this.checked;
    }
}
export function processFormInput(input:Textinput,checkbox:Checkbox){
    if(input instanceof Textinput){
        console.log(`Texy input value: ${input.getValue()}`);
    }
     if(checkbox instanceof Checkbox){
        console.log(`Checkbox input checked: ${checkbox.getValue()}`);
    }
}