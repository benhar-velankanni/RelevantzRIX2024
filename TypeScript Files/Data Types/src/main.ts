// Single variable, single type.
let age: number = 15;
console.log(age);

// Function handling the type.
function greet(name: string) {
  console.log("Hello " + name);
}
greet("John");

// Function with return type.
function add(num1: number, num2: number) {
  return num1 + num2;
}
console.log(add(1, 2));

// Union type.
let value: number | string;
value = 10;
console.log("Value is " + value);
value = "Hello";
console.log("Value is " + value);

// Object type.
type Person = {
  name: string;
  age: number;
};
type Company = {
  name: string;
  location: string;
};

// Object with object type.
let person: Person = {
  name: "John",
  age: 30,
};
let company: Company = {
  name: "Google",
  location: "Mountain View",
};
console.log(person.name + " is " + person.age + " years old");
console.log(company.name + " is located in " + company.location);

// Function with object type.
function greetPerson(person: Person) {
  console.log(
    "Hello there, " + person.name + ", you are of age " + person.age + "."
  );
}
greetPerson(person);

// Type alias / Union type.
type Entity = Person | Company;
function greetEntity(entity: Entity) {
  if ("age" in entity) {
    console.log(
      "Hello " + entity.name + ", you are " + entity.age + " years old."
    );
  } else {
    console.log(
      "Hello " + entity.name + ", you are located in " + entity.location + "."
    );
  }
}
greetEntity(person);
greetEntity(company);

// Array type.
let numbers: number[] = [1, 2, 3, 4, 5];
console.log(numbers);

// Tuple type.
let tuple: [number, string] = [306, "Tuple"];
console.log("Tuple Type: " + tuple);

// Enum type.
enum Color {
  Red = "Red",
  Green = "Green",
  Blue = "Blue",
}
let color: Color = Color.Red;
console.log("Enum Type: " + color);

// Any type.
let anyValue: any = "Any Type";
console.log("Any Type: " + anyValue);
anyValue = 10;
console.log("Any Type: " + anyValue);

// Void type.
function printMessage(message: string): void {
  console.log(message);
}
printMessage("Void Type");

// Unknown type.
let unknownValue: unknown = "Unknown";
console.log(unknownValue);
unknownValue = 10;
console.log(unknownValue);

// Null type.
let nullValue: null = null;
console.log("Null Type: " + nullValue);

// Undefined type.
let undefinedValue: undefined = undefined;
console.log("Undefined Type: " + undefinedValue);

// Literal type.
type Direction = "up" | "down" | "left" | "right";
let direction: Direction = "up";
console.log("Literal Type: " + direction);

// Type assertion.
let message: any = "Type Assertion";
let messageLength: number = (message as string).length;
console.log("Type Assertion: " + messageLength);

// Type inference.
let message2 = "Type Inference";
let messageLength2 = message2.length;
console.log("Type Inference: " + messageLength2);

// Optional type.
type Person2 = {
  name: string;
  age?: number;
};
let person2: Person2 = {
  name: "John",
};
console.log("Optional Type: " + person2.name);

// Readonly type.
type Person3 = {
  readonly name: string;
  readonly age: number;
};
let person3: Person3 = {
  name: "John",
  age: 30,
};
console.log("Readonly Type: " + person3.name);

// Never type.
// function error(message: string): never {
//   throw new Error(message);
// }
// error("Never");

// Union type with classes.
class Dog {
  sound() {
    console.log("Dog goes Woof!");
  }
}

class Cat {
  sound() {
    console.log("Cat goes Meow!");
  }
}

function makeSound(animal: Dog | Cat) {
  animal.sound();
}

const myDog = new Dog();
const myCat = new Cat();

makeSound(myDog);
makeSound(myCat);

// Intersection type.
type Person4 = {
  name: string;
  age: number;
};

type Employee = {
  employeeId: number;
};

type Manager = {
  department: string;
};

type ManagerEmployee = Person4 & Employee & Manager;

const managerEmployee: ManagerEmployee = {
  name: "John",
  age: 30,
  employeeId: 123,
  department: "Sales",
};

console.log("Intersection Type: " + managerEmployee.name);

// Type parameters.
function echo<T>(value: T): T {
  return value;
}
console.log("Type Parameters: " + echo<string>("Hello"));

// Generic classes.
class Queue<T> {
  private data: T[] = [];
  push(item: T) {
    this.data.push(item);
  }
  pop(): T | undefined {
    return this.data.shift();
  }
}
const queue = new Queue<number>();
queue.push(1);
queue.push(2);
queue.push(3);
console.log("Generic Class: " + queue.pop());

//Class Working
class PersonExample {
  firstName: string;
  lastName: string;
  age: number;
  constructor(firstName: string, lastName: string, age: number) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
  }

  getFullName(): string {
    return this.constructor.name === "EmployeeExample"
      ? "The name of the employee is " +
          this.firstName +
          " " +
          this.lastName +
          "."
      : "The name of the person is " +
          this.firstName +
          " " +
          this.lastName +
          ".";
  }
}

class EmployeeExample extends PersonExample {
  employeeId: number;
  constructor(
    firstName: string,
    lastName: string,
    age: number,
    employeeId: number
  ) {
    super(firstName, lastName, age);
    this.employeeId = employeeId;
  }
}

let personValue = new PersonExample("John", "Doe", 30);
let employeeValue = new EmployeeExample("Jane", "Doe", 25, 123);
console.log(personValue.getFullName());
console.log(employeeValue.getFullName());

//Override
class PersonExample2 {
  firstName: string;
  lastName: string;
  age: number;
  constructor(firstName: string, lastName: string, age: number) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
  }
  getFullName(): string {
    return this.constructor.name === "EmployeeExample2"
      ? "The name of the employee is " +
          this.firstName +
          " " +
          this.lastName +
          "."
      : "The name of the person is " +
          this.firstName +
          " " +
          this.lastName +
          ".";
  }
}
class EmployeeExample2 extends PersonExample2 {
  employeeId: number;
  constructor(
    firstName: string,
    lastName: string,
    age: number,
    employeeId: number
  ) {
    super(firstName, lastName, age);
    this.employeeId = employeeId;
  }
  getFullName(): string {
    return (
      "The name of the employee is " +
      this.firstName +
      " " +
      this.lastName +
      "."
    );
  }
}

let personValue2 = new PersonExample2("John", "Doe", 30);
let employeeValue2 = new EmployeeExample2("Jane", "Doe", 25, 123);
console.log(personValue2.getFullName());
console.log(employeeValue2.getFullName());

//Abstract Class
abstract class PersonExample3 {
  firstName: string;
  lastName: string;
  age: number;
  constructor(firstName: string, lastName: string, age: number) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
  }
  abstract getFullName(): string;
}

class EmployeeExample3 extends PersonExample3 {
  employeeId: number;
  constructor(
    firstName: string,
    lastName: string,
    age: number,
    employeeId: number
  ) {
    super(firstName, lastName, age);
    this.employeeId = employeeId;
  }
  getFullName(): string {
    return (
      "The name of the employee is " +
      this.firstName +
      " " +
      this.lastName +
      "."
    );
  }
}

// let personValue3 = new PersonExample3("John", "Doe", 30); //Can not create instance of abstract class.
let employeeValue3 = new EmployeeExample3("Jane", "Doe", 25, 123);
console.log(employeeValue3.getFullName());

//Interface Working
interface PersonExample4 {
  firstName: string;
  lastName: string;
  age: number;
  getFullName(): string;
}
interface EmployeeExample4 extends PersonExample4 {
  employeeId: number;
  getFullName(): string;
}
let personValue4: PersonExample4 = {
  firstName: "John",
  lastName: "Doe",
  age: 30,
  getFullName(): string {
    return (
      "The name of the person is " + this.firstName + " " + this.lastName + "."
    );
  },
};
let employeeValue4: EmployeeExample4 = {
  firstName: "Jane",
  lastName: "Doe",
  age: 25,
  employeeId: 123,
  getFullName(): string {
    return (
      "The name of the employee is " +
      this.firstName +
      " " +
      this.lastName +
      "."
    );
  },
};

console.log(personValue4.getFullName());
console.log(employeeValue4.getFullName());

//Functional Interface
interface Add {
  (a: number, b: number): number;
}
const addition: Add = (a: number, b: number): number => a + b;
console.log("Functional Interface: " + addition(1, 2));