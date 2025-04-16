function greet(name:string){
    var hello = document.querySelector('.hello') as HTMLDivElement;
    hello.innerHTML = `<h1>Hello ${name}</h1>`
}



function add(){
    var num1 = document.querySelector('#num1') as HTMLInputElement;
    var num2 = document.querySelector('#num2') as HTMLInputElement;
    var result = Number(num1.value) + Number(num2.value);
    var result_div = <HTMLDivElement>document.querySelector('#result');
    result_div.innerHTML = result.toString();
    
    
}


function TypeNumGuard(){
    var num_check = Number(document.querySelector('#num-check') as HTMLInputElement);
    var checkResult = document.querySelector('#checkResult') as HTMLDivElement;
    if (typeof num_check === 'number') {
        checkResult.innerHTML = 'Number';
    }
    else {
        checkResult.innerHTML = 'Not a Number';
    }
}

function TypeStrGuard(){
    var check = document.querySelector('#check') as HTMLInputElement;
    var checkResult = document.querySelector('#checkResult') as HTMLDivElement;
    if (typeof check.value === 'string') {
        checkResult.innerHTML = 'String';
    }
    else {
        checkResult.innerHTML = 'Not a String';
    }
}

function displayAge(){
    var age = document.querySelector('#age') as HTMLInputElement;
    var age_div = document.querySelector('.ageResult') as HTMLDivElement;
    if (typeof age === 'string') {
        age_div.innerHTML = "Age is a string";
    }
  
}

type Person = {
    name: string
    age: number
}

type Company = {
    name: string
    employees: number

}

type Info = Person | Company


function displayInfo(info: Info){
    

    var info_div = document.querySelector('.info') as HTMLDivElement;
    if('age' in info){
        info_div.innerHTML = ` Person ${info.name} is accessed`
    }
else{
    info_div.innerHTML = ` Company ${info.name} is accessed`
}
}

const person: Person = {name: 'John', age: 30}
const company: Company = {name: 'John_Company', employees: 30}
    
displayInfo(company)

//Assertion DEmo

let someValue: any = 'this is a string';
let strLength: number = (someValue as string).length;

function findLength(someValue: any) {
    var assertionResult = document.querySelector('#assertion-result') as HTMLDivElement;
    let strLength: number = (someValue as string).length;
    assertionResult.innerHTML = strLength.toString();
}

//Class Demo

class Dog{
    woof(){
       console.log('DOg : woof');
    }
}

class Cat{
    meow(){
        console.log(' Cat : meow');
    }
}


function MakeSound(animal: Dog | Cat){
    if(animal instanceof Dog){
        animal.woof();
    }
    else{
        animal.meow();
    }
}

const dog = new Dog();
const cat = new Cat();

function showSound(){  
    var animal = document.querySelector('#animal-name') as HTMLInputElement; 
    if (animal.value == 'dog'){
        var dog = new Dog();
        MakeSound(dog);
        
    }
    else{
        var cat = new Cat();
        MakeSound(cat);
    }
}