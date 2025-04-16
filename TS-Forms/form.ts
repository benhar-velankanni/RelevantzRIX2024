class TextInput{
    constructor(public value:String){}
    getValue(){
        return this.value
    }
    
}

class NumberInput{
    constructor(public value:Number){}
    getValue(){
        return this.value
    }
}

class DateInput{
    constructor(public value: Date){}
    getValue(){
        return this.value
    }

}

// class CheckBoxInput{
//     constructor(public checked: Boolean){}
//         getValue(){
//             return this.checked
//         }
//     }


function processInput(input: TextInput | DateInput | CheckBoxInput | NumberInput){
    if(input instanceof TextInput){
        console.log(`Text input value : ${input.getValue()}`)

    } 
    if(input instanceof DateInput){
        console.log(`Date input : ${input.getValue()}`)

    } 
    if(input instanceof CheckBoxInput){
        console.log(`Checkbox input : ${input.getValue()}`)

    } 
    else console.log(`Number input : ${input.getValue()}`)
}


var form = document.getElementById('example-form') as HTMLFormElement
form. addEventListener('submit',function(event){
    event.preventDefault()


    const name = document.getElementById('name') as HTMLInputElement
    const age = document.getElementById('age') as HTMLInputElement
    const dob = document.getElementById('dob') as HTMLInputElement
    const check = document.getElementById('check') as HTMLInputElement

    const nameInput = new TextInput(name.value)
    const ageInput = new NumberInput(Number(age.value))
    const birthInput = new DateInput(new Date(dob.value))
    const checkInput = new CheckBoxInput(check.checked)

    processInput(nameInput)
    processInput(ageInput)
    processInput(birthInput)
    processInput(checkInput)
    

})