export class Product {
  name: string;
  price: number;
  inStock: boolean;

  constructor(name: string, price: number, inStock: boolean) {
    this.name = name;
    this.price = price;
    this.inStock = inStock;
  }

  static getInput(formData: FormData): Product {
    const name = formData.get("name") as string;
    const price = parseInt(formData.get("price") as string);
    const inStock = (formData.get("inStock") as string) === "true";
    return new Product(name, price, inStock);
  }

  dispOutput(): void {
    if (!this.inStock) {
      console.log(
        `Product Form: \nProduct: ${this.name} \nPrice: ${this.price} \nIn Stock: No`
      );
      alert(
        `Product Form: \nProduct: ${this.name} \nPrice: ${this.price} \nIn Stock: Yes`
      );
    } else {
      console.log(
        `Product Form: \nProduct: ${this.name} \nPrice: ${this.price} \nIn Stock: Yes`
      );
      alert(
        `Product Form: \nProduct: ${this.name} \nPrice: ${this.price} \nIn Stock: Yes`
      );
    }
  }
}

export class Book {
  title: string;
  author: string;
  pages: number;
  isAvailable: boolean;

  constructor(
    title: string,
    author: string,
    pages: number,
    isAvailable: boolean
  ) {
    this.title = title;
    this.author = author;
    this.pages = pages;
    this.isAvailable = isAvailable;
  }

  static getInput(formData: FormData): Book {
    const title = formData.get("title") as string;
    const author = formData.get("author") as string;
    const pages = parseInt(formData.get("pages") as string);
    const isAvailable = (formData.get("isAvailable") as string) === "true";
    return new Book(title, author, pages, isAvailable);
  }

  dispOutput(): void {
    if (!this.isAvailable) {
      console.log(
        `Book Form: \nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nIs Available: No`
      );
      alert(
        `Book Form: \nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nIs Available: Yes`
      );
    } else {
      console.log(
        `Book Form: \nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nIs Available: Yes`
      );
      alert(
        `Book Form: \nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nIs Available: Yes`
      );
    }
  }
}

export class Car {
  make: string;
  model: string;
  year: number;
  isRunning: boolean;

  constructor(make: string, model: string, year: number, isRunning: boolean) {
    this.make = make;
    this.model = model;
    this.year = year;
    this.isRunning = isRunning;
  }

  static getInput(formData: FormData): Car {
    const make = formData.get("make") as string;
    const model = formData.get("model") as string;
    const year = parseInt(formData.get("year") as string);
    const isRunning = (formData.get("isRunning") as string) === "true";
    return new Car(make, model, year, isRunning);
  }

  dispOutput(): void {
    if (!this.isRunning) {
      console.log(
        `Car Form: \nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nIs Running: No`
      );
      alert(
        `Car Form: \nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nIs Running: Yes`
      );
    } else {
      console.log(
        `Car Form: \nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nIs Running: Yes`
      );
      alert(
        `Car Form: \nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nIs Running: Yes`
      );
    }
  }
}

export class Employee {
  name: string;
  position: string;
  salary: number;
  isFullTime: boolean;

  constructor(
    name: string,
    position: string,
    salary: number,
    isFullTime: boolean
  ) {
    this.name = name;
    this.position = position;
    this.salary = salary;
    this.isFullTime = isFullTime;
  }

  static getInput(formData: FormData): Employee {
    const name = formData.get("name") as string;
    const position = formData.get("position") as string;
    const salary = parseInt(formData.get("salary") as string);
    const isFullTime = (formData.get("isFullTime") as string) === "true";
    return new Employee(name, position, salary, isFullTime);
  }

  dispOutput(): void {
    if (!this.isFullTime) {
      console.log(
        `Employee Form: \nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} \nIs Full Time: No`
      );
      alert(
        `Employee Form: \nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} \nIs Full Time: Yes`
      );
    } else {
      console.log(
        `Employee Form: \nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} \nIs Full Time: Yes`
      );
      alert(
        `Employee Form: \nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} \nIs Full Time: Yes`
      );
    }
  }
}

export class Course {
  title: string;
  instructor: string;
  duration: number; // Duration in hours
  isOnline: boolean;

  constructor(
    title: string,
    instructor: string,
    duration: number,
    isOnline: boolean
  ) {
    this.title = title;
    this.instructor = instructor;
    this.duration = duration;
    this.isOnline = isOnline;
  }

  static getInput(formData: FormData): Course {
    const title = formData.get("title") as string;
    const instructor = formData.get("instructor") as string;
    const duration = parseInt(formData.get("duration") as string);
    const isOnline = (formData.get("isOnline") as string) === "true";
    return new Course(title, instructor, duration, isOnline);
  }

  dispOutput(): void {
    if (!this.isOnline) {
      console.log(
        `Course Form: \nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: No`
      );
      alert(
        `Course Form: \nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: Yes`
      );
    } else {
      console.log(
        `Course Form: \nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: Yes`
      );
      alert(
        `Course Form: \nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: Yes`
      );
    }
  }
}

export function handleFormSubmit(event: SubmitEvent): void {
  event.preventDefault();
  const form = event.target as HTMLFormElement;
  const formData = new FormData(form);
  if ((event.currentTarget as HTMLFormElement).id === "productForm") {
    const product = Product.getInput(formData);
    product.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "bookForm") {
    const book = Book.getInput(formData);
    book.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "carForm") {
    const car = Car.getInput(formData);
    car.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "employeeForm") {
    const employee = Employee.getInput(formData);
    employee.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "courseForm") {
    const course = Course.getInput(formData);
    course.dispOutput();
  }
}