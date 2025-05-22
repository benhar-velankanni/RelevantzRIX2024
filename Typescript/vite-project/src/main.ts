import './style.css'
import typescriptLogo from './typescript.svg'
import { setupCounter } from './counter.ts'
import { Textinput,Checkbox,processFormInput } from './formhandle.ts'
document.getElementById('exampleform')?.addEventListener('submit',function(e){
  e.preventDefault();
  const textinput=document.getElementById('Textinput') as HTMLInputElement;
  const checkbox=document.getElementById('Checkbox') as HTMLInputElement;

  const textinput1=new Textinput(textinput.value);
  const checkbox1=new Checkbox(checkbox.checked);

  processFormInput(textinput1,checkbox1);
})
document.querySelector<HTMLDivElement>('#app')!.innerHTML = `
  <div>
   
    <a href="https://www.typescriptlang.org/" target="_blank">
      <img src="${typescriptLogo}" class="logo vanilla" alt="TypeScript logo" />
    </a>
    <h1>Relevantz</h1>
    <div class="card">
      <button id="counter" type="button"></button>
    </div>
    <p class="read-the-docs">
      Click on the Vite and TypeScript logos to learn more
    </p>
  </div>
`
let age:number = 25;
console.log(`The age is ${age}`);
function greet(name: string) {
  console.log(`Hello, ${name}!`);
}
console.log(greet("1234"));
function checkAge(age: number | string) {
  return `Hello,your age is ${age}`;
}
console.log(checkAge("twenty-five"));
console.log(checkAge(25));
type Person={
  name:string;
  age:number;
}
type Company={
  name:string;
  employees:number
}
const person: Person={name:"Karthic",age:25};
const company:Company={
  name:"Relevantz",employees:1000
}
type Entity=Person|Company;
function displayEntityInfo(entity:Entity){
  console.log(`Name: ${entity.name}`);
  if('age' in entity){
    console.log(`Age: ${entity.age}`);
  }
 else if('employees' in entity){
    console.log(`Employees: ${entity.employees}`);
  }
}
displayEntityInfo(person);
displayEntityInfo(company);
let someValue: any="Welcome to Typescript";
let strlength:number=(<string>someValue).length;
console.log(`String length: ${strlength}`);
let strlength1:number=(someValue as string).length;
console.log(`String length: ${strlength1}`);
function getLength(value: string | number): number {
  if (typeof value === 'string') {
    return value.length;
  } else {
    return value.toString().length;
  }
}
console.log(getLength("Nithis Bangaru"));
console.log(getLength(12345));
//using instanceof in if statements
class Dog{
  bark(){
    console.log("Woof!");
  }
}
class Cat{
  meow(){
    console.log("Meow!");
  }
}
function makeSound(animal: Dog | Cat) {
  if (animal instanceof Dog) {
    animal.bark();
  } else if (animal instanceof Cat) {
    animal.meow();
  }
}
const myDog=new Dog();
const myCat=new Cat();
makeSound(myDog);
makeSound(myCat);
//inheritance
class Personx{
  ssn:string;
  firstName:string;
  lastName:string;
  constructor(ssn:string,firstName:string,lastName:string){
    this.ssn=ssn;
    this.firstName=firstName;
    this.lastName=lastName;
  }
  getFullName():string{
    return `${this.firstName} ${this.lastName}`;
}
}
class Employee extends Personx{
  jobTitle:string;
  constructor(ssn:string,firstName:string,lastName:string,jobTitle:string){
    super(ssn,firstName,lastName);
    this.jobTitle=jobTitle;
  }
}

let employee=new Employee("123-45-6789","John","Doe","Software Engineer");
console.log(`Full name: ${employee.getFullName()}`);
const personx=new Personx("123-45-6789","John","Doe");
console.log(`Full name: ${personx.getFullName()}`);
setupCounter(document.querySelector<HTMLButtonElement>('#counter')!)
class Person1{
  readonly name:string;
  constructor(name:string){
    this.name=name;
  }
}
const john=new Person1("John");
// john.name="Jane"; // Error: Cannot assign to 'name' because it is a read-only property
console.log(john.name);
//method overriding
class Animal1{
  speak():void{
    console.log("Animal speaks");
  }
}
class Dog1 extends Animal1{
  speak():void{
    console.log("Dog barks");
  }
}
const animal=new Animal1();
animal.speak();
const dog=new Dog1();
dog.speak();
class Bird extends Animal1{
  speak(): void {
    super.speak();
    console.log("Bird chirps");
  }
}
const bird=new Bird();
bird.speak();
//overriding access modifiers
class Animal2{
  protected move():void{
    console.log("Animal moves");
  }
}
class Dog2 extends Animal2{
  public move():void{
    console.log("Dog runs");
  }
}
const dog2=new Dog2();
dog2.move();
//interfaces
interface Person3{
  name:string;
  age:number;
  greet():void;
}
const person3:Person3={
  name:"John",
  age:25,
  greet():void{
    console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
  }
}
person3.greet();
interface Animal3{
  species:string;
}
interface Pet extends Animal3{
  name:string;
  isFriendly:boolean;
}
const pet:Pet={
  species:"Dog",
  name:"scooby",
  isFriendly:true
}
console.log(`Pet species: ${pet.species}`);
console.log(`Pet name: ${pet.name}`);
console.log(`Pet is friendly: ${pet.isFriendly}`);
interface Addfunction{
  (a:number,b:number):number;
}
const add:Addfunction=(x,y)=>x+y;
console.log(`Addition result: ${add(2,3)}`);
interface Shape{
  getArea():number;
}
class Rectangle implements Shape{
  constructor(public width:number,public height:number){}
  getArea():number{
    return this.width*this.height;
  }
}
const rectangle=new Rectangle(5,10);
console.log(`Rectangle area: ${rectangle.getArea()}`);
interface Engine{
  horsePower:number;
}
interface Wheel{
  count:number;
}
type Vehicle=Engine&Wheel;
const car:Vehicle={
  horsePower:100,
  count:4
}
console.log(`Horsepower: ${car.horsePower}`);
console.log(`Wheel count: ${car.count}`);