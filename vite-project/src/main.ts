import './style.css'
import typescriptLogo from './typescript.svg'
import viteLogo from '/vite.svg'
import { setupCounter } from './counter.ts'
import { TextInput, CheckboxInput, processFormInput , PasswordInput} from './formHandle.ts'
import { PName, PPrice, PCheckbox, poductFromInput } from './productHandle.ts'
import { Title, Author, Pages, bCheckbox, bookFromInput } from './bookHandle.ts'
import { Make, Model, Year, CCheckbox, carFromInput } from './carHandle.ts'
import {  EName, ESalary,EPosition, ECheckbox, empFromInput } from './empHandle.ts'
import { Cotitle, CoInstructor, Coduration, CoCheckbox, courseFromInput } from './courseHandle.ts'

document.getElementById('exampleform')?.addEventListener('submit', (event) => {
  event.preventDefault();
  const textInput = new TextInput((document.getElementById('textInput') as HTMLInputElement).value);
  const checkboxInput = new CheckboxInput((document.getElementById('checkboxInput') as HTMLInputElement).checked);
  const passwordInput = new PasswordInput((document.getElementById('pass') as HTMLInputElement).value);
  processFormInput(textInput);
  processFormInput(checkboxInput);
  processFormInput(passwordInput);
  //product
});

document.getElementById('products')?.addEventListener('submit', (event) => {
  event.preventDefault();
  const productname = new PName((document.getElementById('pname') as HTMLInputElement).value);
  const pprice = new PPrice(parseInt((document.getElementById('pprice') as HTMLInputElement)?.value ));
  const pcheckbox = new PCheckbox((document.getElementById('pcheckbox') as HTMLInputElement)?.checked);
  poductFromInput(productname);
  poductFromInput(pprice);
  poductFromInput(pcheckbox);
  
});

document.getElementById('Book')?.addEventListener('submit', (event) => {
  event.preventDefault();
  const btitle = new Title((document.getElementById('btitle') as HTMLInputElement).value);
  const bauthor = new Author((document.getElementById('bauthor') as HTMLInputElement).value);
  const bpage = new Pages(parseInt((document.getElementById('bpage') as HTMLInputElement)?.value ));
  const bcheckbox = new bCheckbox((document.getElementById('bcheckbox') as HTMLInputElement)?.checked);
  bookFromInput(btitle);
  bookFromInput(bauthor);
  bookFromInput(bpage);
  bookFromInput(bcheckbox);
});
document.getElementById('Car')?.addEventListener('submit', (event) => {
  event.preventDefault();
  const make = new Make((document.getElementById('make') as HTMLInputElement).value);
  const model = new Model((document.getElementById('model') as HTMLInputElement).value);
  const year = new Year(parseInt((document.getElementById('year') as HTMLInputElement)?.value ));
  const ccheckbox = new CCheckbox((document.getElementById('ccheckbox') as HTMLInputElement)?.checked);
  carFromInput(make);
  carFromInput(model);
  carFromInput(year);
  carFromInput(ccheckbox);
});

document.getElementById('Employee')?.addEventListener('submit', (event) => {
  event.preventDefault();
  const ename = new EName((document.getElementById('ename') as HTMLInputElement).value);
  const eposition = new EPosition((document.getElementById('eposition') as HTMLInputElement).value);
  const esalary = new ESalary(parseInt((document.getElementById('esalary') as HTMLInputElement)?.value ));
  const echeckbox = new ECheckbox((document.getElementById('echeckbox') as HTMLInputElement)?.checked);
  empFromInput(ename);
  empFromInput(eposition);
  empFromInput(esalary);
  empFromInput(echeckbox);
});

document.getElementById('Course')?.addEventListener('submit', (event) => {
  event.preventDefault();
  const cotitle = new Cotitle((document.getElementById('cotitle') as HTMLInputElement).value);
  const coinstructor = new CoInstructor((document.getElementById('coinstructor') as HTMLInputElement).value);
  const coduration = new Coduration(parseInt((document.getElementById('coduration') as HTMLInputElement)?.value ));
  const ccheckbox = new CoCheckbox((document.getElementById('cocheckbox') as HTMLInputElement)?.checked);
  courseFromInput(cotitle);
  courseFromInput(coinstructor);
  courseFromInput(coduration);
  courseFromInput(ccheckbox);
});
// document.querySelector<HTMLDivElement>('#app')!.innerHTML = `
//   <div>
//     <a ref="https://vite.dev" target="_blank">
//       <img src="${viteLogo}" class="logo" alt="Vite logo" />
//     </a>
//     <a href="https://www.typescriptlang.org/" target="_blank">
//       <img src="${typescriptLogo}" class="logo vanilla" alt="TypeScript logo" />
//     </a>
//     <h1>Welcome Jeswanth_Jth</h1>
//     <div class="card">
//       <button id="counter" type="button"></button>
//     </div>
//     <p class="read-the-docs">
//       Click on the Vite and TypeScript logos to learn more
//     </p>
//   </div>
// `
let age: number = 20;
console.log(age);

function greet(name: string):string {

    return `Hello ${name}`
}
console.log(greet("Jeswanth"));
type Person = {
    name: string;
    age: number;
}
type Company={
    name: string;
    employees: number;
}

const person: Person = {
    name: "Jeswanth",
    age: 20,
}
const company: Company = {
    name: "Relevantz",
    employees: 10000,
}
type Entity = Person | Company;
function displayEntity(entity: Entity) {
    if ("name" in entity && "age" in entity) {
        console.log(`Name: ${entity.name}, Age: ${entity.age}`);
    } else {
        console.log(`Name of the Comapny: ${entity.name}, Number of Employees : ${entity.employees}`);
    }
}
let someValue :any ="welcome";
let strLength : number = (<string>someValue).length;
console.log("string length:" + strLength);

let strLength1 : number = (someValue as string).length;
console.log("string length:" + strLength1);

function getLength(value: string | number): number {
    if (typeof value === "string") {
        return  value.length;
    } else {
        return value.toString().length;
    }
}
console.log(getLength("jeswanth"));
console.log(getLength(29012004));

class Dog{
  bark(){
      console.log("Woof!!!");  
  }
}
class Cat{
    meow(){
        console.log("Meow!!!");
    }
}

function makeNoise(animal: Dog | Cat){
    if(animal instanceof Dog){
        animal.bark();
    }
    else{
        animal.meow();
    }
}

const myDog = new Dog();
const myCat = new Cat();


displayEntity(person);
displayEntity(company);
makeNoise(myDog);
makeNoise(myCat);
setupCounter(document.querySelector<HTMLButtonElement>('#counter') ?? {addEventListener: () => {}});


