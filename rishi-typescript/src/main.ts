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


export function handleSubmit(event: SubmitEvent) {
  event.preventDefault();
  const form =event.currentTarget as HTMLFormElement;
  const formData = new FormData(form);
  if((event.currentTarget as HTMLFormElement).id === "productform"){
    console.log(
      "Product Form: \n Name: " +
        formData.get("name") +
        "\n Price: " +
        formData.get("price") +
        "\n In Stock: " +
        formData.get("inStock")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "bookform"){
    console.log(
      "Book Form: \n Title: " +
        formData.get("title") +
        "\n Author: " +
        formData.get("author") +
        "\n Pages: " +
        formData.get("pages") +
        "\n Is Available: " +
        formData.get("isAvailable")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "carform"){
    console.log(
      "Car Form: \n Make: " +
        formData.get("make") +
        "\n Model: " +
        formData.get("model") +
        "\n Year: " +
        formData.get("year") +
        "\n Is Running: " +
        formData.get("isRunning")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "courseform"){
    console.log(
      "Course Form: \n Name: " +
        formData.get("name") +
        "\n Price: " +
        formData.get("price") +
        "\n Is Free: " +
        formData.get("isFree")
    );
  }
  else if((event.currentTarget as HTMLFormElement).id === "employeeform"){
    console.log(
      "Employee Form: \n Name: " +
        formData.get("name") +
        "\n Position: " +
        formData.get("position") +
        "\n Salary: " +
        formData.get("salary") +
        "\n Is Full Time: " +
        formData.get("isFullTime")
    );
  }
  if(event.currentTarget != null){
    (event.currentTarget as HTMLFormElement).reset();
  }
}

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

class Item
{
    name: string;
    price: number;
    instock: boolean;
    constructor(name: string, price: number, instock: boolean)
    {
        this.name = name;
        this.price = price;
        this.instock = instock;
    }
    // getDetails(): string
    // {
    //     return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}`;
    // }
}

class Product extends Item
{
    description: string;
    constructor(name: string, price: number, instock: boolean, description: string)
    {
        super(name, price, instock);
        this.description = description;
    }

    getDetails(): string
    {
        return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Description: ${this.description}`;
    }
}

class Book extends Item
{
    title: string;
    author: string;
    pages: number;
    isAvailable: boolean;
    constructor(name: string, price: number, instock: boolean, title: string, author: string, pages: number, isAvailable: boolean)
    {
        super(name, price, instock);
        this.title = title;
        this.author = author;
        this.pages = pages;
        this.isAvailable = isAvailable;
    }
    getDetails(): string {
        return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}, Is Available: ${this.isAvailable}`;
    }
}

class Car extends Item
{
    make: string;
    model: string;
    year: number;
    isRunning: boolean;
    constructor(name: string, price: number, instock: boolean, make: string, model: string, year: number, isRunning: boolean)
    {
        super(name, price, instock);
        this.make = make;
        this.model = model;
        this.year = year;
        this.isRunning = isRunning;
    }
    getDetails(): string {
        return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, Is Running: ${this.isRunning}`;
    }
}

class Employee extends Item
{
    position: string;
    salary: number;
    isFullTime: boolean;
    constructor(name: string, price: number, instock: boolean, position: string, salary: number, isFullTime: boolean)
    {
        super(name, price, instock);
        this.position = position;
        this.salary = salary;
        this.isFullTime = isFullTime;
    }
    getDetails(): string {    
        return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Position: ${this.position}, Salary: ${this.salary}, Is Full Time: ${this.isFullTime}`;
    }
}

class Course extends Item
{
    title: string;
    instructor: string;
    duration: number; 
    isOnline: boolean;
    constructor(name: string, price: number, instock: boolean, title: string, instructor: string, duration: number, isOnline: boolean)
    {
        super(name, price, instock);
        this.title = title;
        this.instructor = instructor;
        this.duration = duration;
        this.isOnline = isOnline;
    }
    getDetails(): string {
        return `Name: ${this.name}, Price: ${this.price}, Instock: ${this.instock}, Title: ${this.title}, Instructor: ${this.instructor}, Duration: ${this.duration + " hours"}, Is Online: ${this.isOnline}`;
    }
}

let p = new Item("Phone", 15000, true);
let m = new Product("Monitor", 25000, true, "high quality");
let b = new Book("The Alchemist", 500, true, "The Alchemist", "Paulo Coelho", 163, true);
let c = new Car("Tesla Model S", 100000, true, "Tesla", "Model S", 2022, true);
let e = new Employee("John Doe", 50000, true, "Developer", 80000, true);
let co = new Course("TypeScript Fundamentals", 200, true, "TypeScript Fundamentals", "Rishi", 4, true);
// console.log(p.getDetails());
console.log(m.getDetails());
console.log(b.getDetails());
console.log(c.getDetails());
console.log(e.getDetails());
console.log(co.getDetails());

