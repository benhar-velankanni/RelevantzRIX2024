export class Product {
  name: string;
  price: number;
  inStock: boolean;

  constructor(name: string, price: number, inStock: boolean) {
    this.name = name;
    this.price = price;
    this.inStock = inStock;
  }
}

export class Phone extends Product {
  processor: string;
  ram: number;
  storage: number;

  constructor(
    name: string,
    price: number,
    inStock: boolean,
    processor: string,
    ram: number,
    storage: number
  ) {
    super(name, price, inStock);
    this.processor = processor;
    this.ram = ram;
    this.storage = storage;
  }

  static getInput(formData: FormData): Phone {
    const name = formData.get("name") as string;
    const price = parseInt(formData.get("price") as string);
    const inStock = (formData.get("inStock") as string) === "true";
    const processor = formData.get("processor") as string;
    const ram = parseInt(formData.get("ram") as string);
    const storage = parseInt(formData.get("storage") as string);
    return new Phone(name, price, inStock, processor, ram, storage);
  }

  dispOutput(): void {
    if (!this.inStock) {
      console.log(
        `Phone Details: \n===================================\nName: ${this.name} \nPrice: ${this.price} INR \nProcessor: ${this.processor} \nRAM: ${this.ram} GB \nStorage: ${this.storage} GB \nIn Stock: No`
      );
      alert(
        `Phone Details: \n===================================\nName: ${this.name} \nPrice: ${this.price} INR \nProcessor: ${this.processor} \nRAM: ${this.ram} GB \nStorage: ${this.storage} GB \nIn Stock: No`
      );
    } else {
      console.log(
        `Phone Details: \n===================================\nName: ${this.name} \nPrice: ${this.price} INR \nProcessor: ${this.processor} \nRAM: ${this.ram} GB \nStorage: ${this.storage} GB \nIn Stock: Yes`
      );
      alert(
        `Phone Details: \n===================================\nName: ${this.name} \nPrice: ${this.price} INR \nProcessor: ${this.processor} \nRAM: ${this.ram} GB \nStorage: ${this.storage} GB \nIn Stock: Yes`
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
}

export class HarryPotterBook extends Book {
  house: string;
  volumeNo: number;

  constructor(
    title: string,
    author: string,
    pages: number,
    isAvailable: boolean,
    house: string,
    volumeNo: number
  ) {
    super(title, author, pages, isAvailable);
    this.house = house;
    this.volumeNo = volumeNo;
  }

  static getInput(formData: FormData): HarryPotterBook {
    const title = formData.get("title") as string;
    const author = formData.get("author") as string;
    const pages = parseInt(formData.get("pages") as string);
    const isAvailable = (formData.get("isAvailable") as string) === "true";
    const house = formData.get("house") as string;
    const volumeNo = parseInt(formData.get("volumeNo") as string);
    return new HarryPotterBook(
      title,
      author,
      pages,
      isAvailable,
      house,
      volumeNo
    );
  }

  dispOutput(): void {
    if (!this.isAvailable) {
      console.log(
        `Harry Potter Book Details: \n===================================\nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nPrefered House: ${this.house} \nVolume No: ${this.volumeNo} \nIs Available: No`
      );
      alert(
        `Harry Potter Book Details: \n===================================\nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nPrefered House: ${this.house} \nVolume No: ${this.volumeNo} \nIs Available: No`
      );
    } else {
      console.log(
        `Harry Potter Book Details: \n===================================\nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nPrefered House: ${this.house} \nVolume No: ${this.volumeNo} \nIs Available: Yes`
      );
      alert(
        `Harry Potter Book Details: \n===================================\nTitle: ${this.title} \nAuthor: ${this.author} \nPages: ${this.pages} \nPrefered House: ${this.house} \nVolume No: ${this.volumeNo} \nIs Available: Yes`
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
}

export class Toyota extends Car {
  mileage: number;
  seats: number;

  constructor(
    make: string,
    model: string,
    year: number,
    isRunning: boolean,
    mileage: number,
    seats: number
  ) {
    super(make, model, year, isRunning);
    this.mileage = mileage;
    this.seats = seats;
  }

  static getInput(formData: FormData): Toyota {
    const make = formData.get("make") as string;
    const model = formData.get("model") as string;
    const year = parseInt(formData.get("year") as string);
    const isRunning = (formData.get("isRunning") as string) === "true";
    const mileage = parseInt(formData.get("mileage") as string);
    const seats = parseInt(formData.get("seats") as string);
    return new Toyota(make, model, year, isRunning, mileage, seats);
  }

  dispOutput(): void {
    if (!this.isRunning) {
      console.log(
        `Toyota Car Details: \n===================================\nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nMileage: ${this.mileage} KM \nSeats: ${this.seats} \nIs Running: No`
      );
      alert(
        `Toyota Car Details: \n===================================\nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nMileage: ${this.mileage} KM \nSeats: ${this.seats} \nIs Running: No`
      );
    } else {
      console.log(
        `Toyota Car Details: \n===================================\nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nMileage: ${this.mileage} KM \nSeats: ${this.seats} \nIs Running: Yes`
      );
      alert(
        `Toyota Car Details: \n===================================\nMake: ${this.make} \nModel: ${this.model} \nYear: ${this.year} \nMileage: ${this.mileage} KM \nSeats: ${this.seats} \nIs Running: Yes`
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
}

export class Manager extends Employee {
  department: string;
  bonus: number;

  constructor(
    name: string,
    position: string,
    salary: number,
    isFullTime: boolean,
    department: string,
    bonus: number
  ) {
    super(name, position, salary, isFullTime);
    this.department = department;
    this.bonus = bonus;
  }

  static getInput(formData: FormData): Manager {
    const name = formData.get("name") as string;
    const position = formData.get("position") as string;
    const salary = parseInt(formData.get("salary") as string);
    const isFullTime = (formData.get("isFullTime") as string) === "true";
    const department = formData.get("department") as string;
    const bonus = parseInt(formData.get("bonus") as string);
    return new Manager(name, position, salary, isFullTime, department, bonus);
  }

  dispOutput(): void {
    if (!this.isFullTime) {
      console.log(
        `Manager Details: \n===================================\nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} INR \nIs Full Time: No \nDepartment: ${this.department} \nBonus: ${this.bonus} INR`
      );
      alert(
        `Manager Details: \n===================================\nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} INR \nIs Full Time: No \nDepartment: ${this.department} \nBonus: ${this.bonus} INR`
      );
    } else {
      console.log(
        `Manager Details: \n===================================\nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} INR \nIs Full Time: Yes \nDepartment: ${this.department} \nBonus: ${this.bonus} INR`
      );
      alert(
        `Manager Details: \n===================================\nName: ${this.name} \nPosition: ${this.position} \nSalary: ${this.salary} INR \nIs Full Time: Yes \nDepartment: ${this.department} \nBonus: ${this.bonus} INR`
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
}

export class WebCourse extends Course {
  chapters: number;

  constructor(
    title: string,
    instructor: string,
    duration: number,
    isOnline: boolean,
    chapters: number
  ) {
    super(title, instructor, duration, isOnline);
    this.chapters = chapters;
  }

  static getInput(formData: FormData): WebCourse {
    const title = formData.get("title") as string;
    const instructor = formData.get("instructor") as string;
    const duration = parseInt(formData.get("duration") as string);
    const isOnline = (formData.get("isOnline") as string) === "true";
    const chapters = parseInt(formData.get("chapters") as string);
    return new WebCourse(title, instructor, duration, isOnline, chapters);
  }

  dispOutput(): void {
    if (this.isOnline) {
      console.log(
        `Web Course Details: \n===================================\nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: Yes \nChapters: ${this.chapters}`
      );
      alert(
        `Web Course Details: \n===================================\nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: Yes \nChapters: ${this.chapters}`
      );
    } else {
      console.log(
        `Web Course Details: \n===================================\nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: No \nChapters: ${this.chapters}`
      );
      alert(
        `Web Course Details: \n===================================\nTitle: ${this.title} \nInstructor: ${this.instructor} \nDuration: ${this.duration} \nIs Online: No \nChapters: ${this.chapters}`
      );
    }
  }
}

export function handleFormSubmit(event: SubmitEvent): void {
  event.preventDefault();
  const form = event.target as HTMLFormElement;
  const formData = new FormData(form);
  if ((event.currentTarget as HTMLFormElement).id === "phoneForm") {
    const phone = Phone.getInput(formData);
    phone.dispOutput();
  } else if (
    (event.currentTarget as HTMLFormElement).id === "harryPotterForm"
  ) {
    const harryPotterBook = HarryPotterBook.getInput(formData);
    harryPotterBook.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "toyotaForm") {
    const toyota = Toyota.getInput(formData);
    toyota.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "managerForm") {
    const manager = Manager.getInput(formData);
    manager.dispOutput();
  } else if ((event.currentTarget as HTMLFormElement).id === "webCourseForm") {
    const webCourse = WebCourse.getInput(formData);
    webCourse.dispOutput();
  }
  (event.currentTarget as HTMLFormElement).reset();
}
