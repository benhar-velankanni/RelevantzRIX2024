// import './style.css'
// import { TextInput, CheckboxInput, processFormInput } from './Formhandler'


// document.getElementById('exampleForm')!.addEventListener('submit', (event) => {
//   event.preventDefault();

//   const textInputElement = document.getElementById('name') as HTMLInputElement;
//   const checkboxInputElement = document.getElementById('confirmation') as HTMLInputElement;

//   const textInput = new TextInput(textInputElement.value);
//   const checkboxInput = new CheckboxInput(checkboxInputElement.checked);

//   processFormInput(textInput);
//   processFormInput(checkboxInput);
// });


//For form------------------------------------------------------------------------------------------------


// export function handleSubmit(event: SubmitEvent) {
//   event.preventDefault();
//   const form =event.currentTarget as HTMLFormElement;
//   const formData = new FormData(form);
//   if((event.currentTarget as HTMLFormElement).id === "productform"){
//     console.log(
//       "Product Form: \n Name: " +
//         formData.get("name") +
//         "\n Price: " +
//         formData.get("price") +
//         "\n In Stock: " +
//         formData.get("inStock")
//     );
//   }
//   else if((event.currentTarget as HTMLFormElement).id === "bookform"){
//     console.log(
//       "Book Form: \n Title: " +
//         formData.get("title") +
//         "\n Author: " +
//         formData.get("author") +
//         "\n Pages: " +
//         formData.get("pages") +
//         "\n Is Available: " +
//         formData.get("isAvailable")
//     );
//   }
//   else if((event.currentTarget as HTMLFormElement).id === "carform"){
//     console.log(
//       "Car Form: \n Make: " +
//         formData.get("make") +
//         "\n Model: " +
//         formData.get("model") +
//         "\n Year: " +
//         formData.get("year") +
//         "\n Is Running: " +
//         formData.get("isRunning")
//     );
//   }
//   else if((event.currentTarget as HTMLFormElement).id === "courseform"){
//     console.log(
//       "Course Form: \n Name: " +
//         formData.get("name") +
//         "\n Price: " +
//         formData.get("price") +
//         "\n Is Free: " +
//         formData.get("isFree")
//     );
//   }
//   else if((event.currentTarget as HTMLFormElement).id === "employeeform"){
//     console.log(
//       "Employee Form: \n Name: " +
//         formData.get("name") +
//         "\n Position: " +
//         formData.get("position") +
//         "\n Salary: " +
//         formData.get("salary") +
//         "\n Is Full Time: " +
//         formData.get("isFullTime")
//     );
//   }
//   if(event.currentTarget != null){
//     (event.currentTarget as HTMLFormElement).reset();
//   }
// }

//for contructor-----------------------------------------------------------------------------


// class Personex{
   
//   firstname:String;
//   lastname:String;
//   ssn:String;

//   constructor(ssn:String,firstname:   String,lastname:String){
//       this.ssn=ssn;
//       this.firstname=firstname;
//       this.lastname=lastname;
//   }
//   getFullName(){
//       return`${this.firstname} ${this.lastname} ${this.ssn}`;
//   }
// }

// class Employee extends Personex{


//   constructor(
//       firstname: String,
//       lastname: String,
//       private jobtitle: String
//   ){
//       super(jobtitle,firstname,lastname);
//   } 
// }
// let personval=new Personex("1234","Rishi","Kesav");
// console.log(personval.getFullName());
// let employee=new Employee("Rishi","Kesav","Developer");
// console.log(employee.getFullName());


//task for contructor------------------------------------------------------------------------

// class Item
// {
//     name: string;
//     price: number;
//     instock: boolean;
//     constructor(name: string, price: number, instock: boolean)
//     {
//         this.name = name;
//         this.price = price;
//         this.instock = instock;
//     }
//     // getDetails(): string
//     // {
//     //     return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}`;
//     // }
// }

// class Product extends Item
// {
//     description: string;
//     constructor(name: string, price: number, instock: boolean, description: string)
//     {
//         super(name, price, instock);
//         this.description = description;
//     }

//     getDetails(): string
//     {
//         return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Description: ${this.description}`;
//     }
// }

// class Book extends Item
// {
//     title: string;
//     author: string;
//     pages: number;
//     isAvailable: boolean;
//     constructor(name: string, price: number, instock: boolean, title: string, author: string, pages: number, isAvailable: boolean)
//     {
//         super(name, price, instock);
//         this.title = title;
//         this.author = author;
//         this.pages = pages;
//         this.isAvailable = isAvailable;
//     }
//     getDetails(): string {
//         return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}, Is Available: ${this.isAvailable}`;
//     }
// }

// class Car extends Item
// {
//     make: string;
//     model: string;
//     year: number;
//     isRunning: boolean;
//     constructor(name: string, price: number, instock: boolean, make: string, model: string, year: number, isRunning: boolean)
//     {
//         super(name, price, instock);
//         this.make = make;
//         this.model = model;
//         this.year = year;
//         this.isRunning = isRunning;
//     }
//     getDetails(): string {
//         return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, Is Running: ${this.isRunning}`;
//     }
// }

// class Employee extends Item
// {
//     position: string;
//     salary: number;
//     isFullTime: boolean;
//     constructor(name: string, price: number, instock: boolean, position: string, salary: number, isFullTime: boolean)
//     {
//         super(name, price, instock);
//         this.position = position;
//         this.salary = salary;
//         this.isFullTime = isFullTime;
//     }
//     getDetails(): string {    
//         return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Position: ${this.position}, Salary: ${this.salary}, Is Full Time: ${this.isFullTime}`;
//     }
// }

// class Course extends Item
// {
//     title: string;
//     instructor: string;
//     duration: number; 
//     isOnline: boolean;
//     constructor(name: string, price: number, instock: boolean, title: string, instructor: string, duration: number, isOnline: boolean)
//     {
//         super(name, price, instock);
//         this.title = title;
//         this.instructor = instructor;
//         this.duration = duration;
//         this.isOnline = isOnline;
//     }
//     getDetails(): string {
//         return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Title: ${this.title}, Instructor: ${this.instructor}, Duration: ${this.duration + " hours"}, Is Online: ${this.isOnline}`;
//     }
// }

// let p = new Item("Phone", 15000, true);
// let m = new Product("Monitor", 25000, true, "high quality");
// let b = new Book("The Alchemist", 500, true, "The Alchemist", "Paulo Coelho", 163, true);
// let c = new Car("Tesla Model S", 100000, true, "Tesla", "Model S", 2022, true);
// let e = new Employee("John Doe", 50000, true, "Developer", 80000, true);
// let co = new Course("TypeScript Fundamentals", 200, true, "TypeScript Fundamentals", "Rishi", 4, true);
// // console.log(p.getDetails());
// console.log(m.getDetails());
// console.log(b.getDetails());
// console.log(c.getDetails());
// console.log(e.getDetails());
// console.log(co.getDetails());


//readonly property--------------------------------------------------------------

// class person{
//   readonly name: string;
//   constructor(name: string){
//     this.name = name;
//   }
// }

// let p = new person("Rishi");
// console.log(p.name);


//override method---------------------------------------------------------------

// class Animal{
//   speak() : void{
//     console.log("Animal makes a sound");
    
//   }
// }

// class Dog extends Animal{
//   speak() : void{
//     console.log("Dog barks");
//   }
// }

// const animal = new Animal();
// animal.speak();

// const dog = new Dog();
// dog.speak(); 
// //super keyword---------------------------------------------------------------
// class Bird extends Animal{
//   speak() : void{
//     super.speak();
//     console.log("Bird chirps");
//   }
// }

// const bird = new Bird();
// bird.speak();

//override with acess modifiers-------------------------------------------------

// class Vehicle{
//   protected move(): void{
//     console.log("Vehicle moves");
//   }
// }

// class Car extends Vehicle{
//   public move(): void{
//     console.log("Car drives");
//   }
// }

// const car = new Car();
// car.move();

//interface---------------------------------------------------------------

// interface Person{
//   name: string;
//   age: number;
//   greet(): void;
// }

// const person: Person = {
//   name: "Rishi",
//   age: 23,
//   greet(){
//     console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
//   }
// }

// person.greet();

//Extending interface------------------------------------------------------------
// interface Animal{
//   species: string;
// }

// interface Dog extends Animal{
//   breed: string;
  
// }

// const dog: Dog = {
//   species: "Canine",
//   breed: "Golden Retriever"
// }

// interface AddFunction{
//   (a: number, b: number): number;
// }

// const add: AddFunction = (x,y) => x + y;
// console.log(add(2,3));
  
//class implementation

// interface Shape{
//   area(): number;
// }
// class Rectangle implements Shape{
//   constructor(public width: number, public height: number) {}
//   area(): number {
//     return this.width * this.height;
//   }
// }
// const rect = new Rectangle(10, 20);
// console.log(rect.area());

//combining multiple interfaces

// interface Engine{
//   horsePower: number;
// }
// interface Wheel{
//   count: number;
// }
// type Vehicle = Engine & Wheel;

// const car : Vehicle = {
//   horsePower: 100,
//   count: 4
// }
// console.log(car);

//task-----------------------------------------------------------------------------
//create constructor for each Class and get values from the Form:



// import {ProductItem,BookItem,CarItem,EmployeeItem,CourseItem} from './submain';
 
// var p1=document.getElementById('pid') as HTMLInputElement;
// var p2=document.getElementById('pname') as HTMLInputElement;
// var p3=document.getElementById('pprice') as HTMLInputElement;
// var p4=document.getElementById('pis') as HTMLInputElement;
// var bu1=document.getElementById('b1') as HTMLInputElement;
 
// bu1.addEventListener('click',function(e){
//     e.preventDefault();
//     var id=Number(p1.value);
//     var name=p2.value;
//     var price=Number(p3.value);
//     var inStock=p4.checked;
//     var p=new ProductItem(id,name,price,inStock);
//     p.dis();
// })
 
// var b1=document.getElementById('bid') as HTMLInputElement;
// var b2=document.getElementById('bname') as HTMLInputElement;
// var b3=document.getElementById('bauthor') as HTMLInputElement;
// var b4=document.getElementById('bpages') as HTMLInputElement;
// var bu2=document.getElementById('b2') as HTMLInputElement;
 
// bu2.addEventListener('click',function(e){
//     e.preventDefault();
//     var id=Number(b1.value);
//     var name=b2.value;
//     var author=b3.value;
//     var pages=Number(b4.value);
//     var b=new BookItem({id,name,author,pages});
//     b.dis();
// })
 
// var c1=document.getElementById('cid') as HTMLInputElement;
// var c2=document.getElementById('cname') as HTMLInputElement;
// var c3=document.getElementById('cmake') as HTMLInputElement;
// var c4=document.getElementById('cmodel') as HTMLInputElement;
// var c5=document.getElementById('cyear') as HTMLInputElement;
// var c6=document.getElementById('cis') as HTMLInputElement;
// var bu3=document.getElementById('b3') as HTMLInputElement;
 
// bu3.addEventListener('click',function(e){
//     e.preventDefault();
//     var id=Number(c1.value);
//     var name=c2.value;
//     var make=c3.value;
//     var model=c4.value;
//     var year=c5.value;
//     var isRunning=c6.checked;
//     var c=new CarItem(id,name,make,model,year,isRunning);
//     c.dis();
// })
 
// var e1=document.getElementById('eid') as HTMLInputElement;
// var e2=document.getElementById('ename') as HTMLInputElement;
// var e3=document.getElementById('epos') as HTMLInputElement;
// var e4=document.getElementById('esalary') as HTMLInputElement;
// var e5=document.getElementById('eis') as HTMLInputElement;
// var bu4=document.getElementById('b4') as HTMLInputElement;
 
// bu4.addEventListener('click',function(e){
//     e.preventDefault();
//     var id=Number(e1.value);
//     var name=e2.value;
//     var position=e3.value;
//     var salary=Number(e4.value);
//     var isFullTime=e5.checked;
//     var f=new EmployeeItem(id,name,position,salary,isFullTime);
//     f.dis();
// })
 
// var co1=document.getElementById('coid') as HTMLInputElement;
// var co2=document.getElementById('coname') as HTMLInputElement;
// var co3=document.getElementById('coins') as HTMLInputElement;
// var co4=document.getElementById('codur') as HTMLInputElement;
// var co5=document.getElementById('cois') as HTMLInputElement;
// var bu5=document.getElementById('b5') as HTMLInputElement;
 
// bu5.addEventListener('click',function(e){
//     e.preventDefault();
//     var id=Number(co1.value);
//     var name=co2.value;
//     var instructor=co3.value;
//     var duration=Number(co4.value);
//     var isOnline=co5.checked;
//     var c=new CourseItem(id,name,instructor,duration,isOnline);
//     c.dis();
// })

//generic type arguments------------------------------------------------------------

// function identity<T>(value:T):T{
//     return value;
// }

// const numberIdentity = identity<number>(5);
// const stringIdentity = identity<string>('hello');

// console.log(numberIdentity);
// console.log(stringIdentity);

//another example of generic type arguments for Interface------------------------------------------------------------

// interface Box<T>{
//   content :T;
// }
// const numberBox:Box<number>={
//   content:5
// }
// const stringBox:Box<string>={
//   content:'hello'
// }

// console.log(numberBox);
// console.log(stringBox);

//another example of generic type arguments for Class------------------------------------------------------------

// class DataStorage<T>{
//     private data:T[]=[];
//     addItem(item:T){
//         this.data.push(item);
//     }
//     removeItem(item:T){
//         this.data.splice(this.data.indexOf(item),1);
//     }
//     getItems(){
//         return [...this.data];
//     }
// }

// const textStorage=new DataStorage<string>();
// textStorage.addItem('Rishi');
// textStorage.addItem('K7');
// textStorage.removeItem('Vignesh');
// console.log(textStorage.getItems());

//another example of generic type arguments for  ExtendsClass------------------------------------------------------------

// class Item<T>{
//   id:T;
//   name:string;
//   price:number;
//   constructor(id:T,name:string,price:number){
//       this.id=id;
//       this.name=name;
//       this.price=price;
//   }
//   displayInfo() :string{
//       return `id:${this.id},name:${this.name},price:${this.price}`;
//   }
// }

// class ProductItem<T> extends Item<T>{
//   expiryDate:Date;
//   constructor(id:T,name:string,price:number,expiryDate:Date){
//       super(id,name,price);
//       this.expiryDate=expiryDate;
//   }
//   isExpired():boolean{
//     const today=new Date();
//     return this.expiryDate>today;
//   }

//   displayInfo() :string{
//     const isExpired=this.isExpired() ? 'Expired' : 'Not Expired';
//     return `id:${this.id},name:${this.name},price:${this.price},expiryDate:${this.expiryDate},isExpired:${isExpired}`;
//   }

// }

// const item=new Item<string>('1','Rishi',100);
// console.log(item.displayInfo());

// const productItem=new ProductItem<string>('1','Rishi dvrf',100,new Date('2023-01-01'));
// console.log(productItem.displayInfo());


import axios, { AxiosError } from "axios";

const API_URL = "http://localhost:3000/users";

// Helper function to get input value by id
const getInputValue = (id: string): string => (document.getElementById(id) as HTMLInputElement).value;



// Create a new user
document.getElementById("create")?.addEventListener("click", async () => {
    const id = getInputValue("c_id");
    const name = getInputValue("name");
    const email = getInputValue("email");
    try {
        const response = await axios.post(API_URL, { id,name, email });
        console.log("User created", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error creating user", error.response?.data);
        } else {
            console.error("Error creating user", error);
        }
    }
});

// Read users
document.getElementById("read")?.addEventListener("click", async () => {
    try {
        const response = await axios.get(API_URL);
        console.log("Users fetched", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error fetching users", error.response?.data);
        } else {
            console.error("Error fetching users", error);
        }
    }
});

// Update a user
document.getElementById("update")?.addEventListener("click", async () => {
    const id = getInputValue("update-id");
    const name = getInputValue("update-name");
    const email = getInputValue("update-email");
    try {
        const response = await axios.put(`${API_URL}/${id}`, { id,name, email });
        console.log("User updated", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error updating user", error.response?.data);
        } else {
            console.error("Error updating user", error);
        }
    }
});


// Delete a user
document.getElementById("delete")?.addEventListener("click", async () => {
    const id = getInputValue("delete-id");
    try {
        const response = await axios.delete(`${API_URL}/${id}`);
        console.log("User deleted", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error deleting user", error.response?.data);
        } else {
            console.error("Error deleting user", error);
        }
    }
});

const API_URL1= "http://localhost:3000/transactions";
 
// Create transaction
document.getElementById("create-trans")?.addEventListener("click", async () => {
    const id = getInputValue("trans-id");
    const transName = getInputValue("trans-name");
    const transDescription = getInputValue("trans-description");
    const transMode = getInputValue("trans-mode");
    try {
        const response = await axios.post(API_URL1, { id,transName, transDescription, transMode });
        console.log("Transaction created", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error creating transaction", error.response?.data);
        } else {
            console.error("Error creating transaction", error);
        }
    }
});
 
// Read transactions
document.getElementById("read-trans")?.addEventListener("click", async () => {
    try {
        const response = await axios.get(API_URL1);
        console.log("Transactions fetched", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error fetching transactions", error.response?.data);
        } else {
            console.error("Error fetching transactions", error);
        }
    }
});
// Update transaction
document.getElementById("update-trans")?.addEventListener("click", async () => {
    const id = getInputValue("update-trans-id");
    const transName = getInputValue("update-trans-name");
    const transDescription = getInputValue("update-trans-description");
    const transMode = getInputValue("update-trans-mode");
    try {
        const response = await axios.put(`${API_URL1}/${id}`, { id,transName, transDescription, transMode });
        console.log("Transaction updated", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error updating transaction", error.response?.data);
        } else {
            console.error("Error updating transaction", error);
        }
    }
});
 
 
// Delete transaction
document.getElementById("delete-trans")?.addEventListener("click", async () => {
    const id = getInputValue("delete-trans-id");
    try {
        const response = await axios.delete(`${API_URL1}/${id}`);
        console.log("Transaction deleted", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error deleting transaction", error.response?.data);
        } else {
            console.error("Error deleting transaction", error);
        }
    }
});