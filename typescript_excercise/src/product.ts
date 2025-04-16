
class Product {
  name: string;
  price: number;
  inStock: boolean;

  constructor(name: string, price: number, inStock: boolean) {
    this.name = name;
    this.price = price;
    this.inStock = inStock;
  }
}

// Function to create and display Product instance
function createAndDisplayProduct(name: string, price: number, inStock: boolean) {
  const product = new Product(name, price, inStock);
  console.log(`Product Details:`);
  console.log(`Name: ${product.name}`);
  console.log(`Price: $${product.price.toFixed(2)}`);
  console.log(`In Stock: ${product.inStock ? 'Yes' : 'No'}`);
}

// Book class
class Book {
  title: string;
  author: string;
  pages: number;
  isAvailable: boolean;

  constructor(title: string, author: string, pages: number, isAvailable: boolean) {
    this.title = title;
    this.author = author;
    this.pages = pages;
    this.isAvailable = isAvailable;
  }
}

// Function to create and display Book instance
function createAndDisplayBook(title: string, author: string, pages: number, isAvailable: boolean) {
  const book = new Book(title, author, pages, isAvailable);
  console.log(`Book Details:`);
  console.log(`Title: ${book.title}`);
  console.log(`Author: ${book.author}`);
  console.log(`Pages: ${book.pages}`);
  console.log(`Is Available: ${book.isAvailable ? 'Yes' : 'No'}`);
}

// Car class
class Car {
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

// Function to create and display Car instance
function createAndDisplayCar(make: string, model: string, year: number, isRunning: boolean) {
  const car = new Car(make, model, year, isRunning);
  console.log(`Car Details:`);
  console.log(`Make: ${car.make}`);
  console.log(`Model: ${car.model}`);
  console.log(`Year: ${car.year}`);
  console.log(`Is Running: ${car.isRunning ? 'Yes' : 'No'}`);
}

// Employee class
class Employee {
  name: string;
  position: string;
  salary: number;
  isFullTime: boolean;

  constructor(name: string, position: string, salary: number, isFullTime: boolean) {
    this.name = name;
    this.position = position;
    this.salary = salary;
    this.isFullTime = isFullTime;
  }
}

// Function to create and display Employee instance
function createAndDisplayEmployee(name: string, position: string, salary: number, isFullTime: boolean) {
  const employee = new Employee(name, position, salary, isFullTime);
  console.log(`Employee Details:`);
  console.log(`Name: ${employee.name}`);
  console.log(`Position: ${employee.position}`);
  console.log(`Salary: $${employee.salary.toFixed(2)}`);
  console.log(`Is Full-time: ${employee.isFullTime ? 'Yes' : 'No'}`);
}

// Course class
class Course {
  title: string;
  instructor: string;
  duration: number; // Duration in hours
  isOnline: boolean;

  constructor(title: string, instructor: string, duration: number, isOnline: boolean) {
    this.title = title;
    this.instructor = instructor;
    this.duration = duration;
    this.isOnline = isOnline;
  }
}

// Function to create and display Course instance
function createAndDisplayCourse(title: string, instructor: string, duration: number, isOnline: boolean) {
  const course = new Course(title, instructor, duration, isOnline);
  console.log(`Course Details:`);
  console.log(`Title: ${course.title}`);
  console.log(`Instructor: ${course.instructor}`);
  console.log(`Duration: ${course.duration} hours`);
  console.log(`Is Online: ${course.isOnline ? 'Yes' : 'No'}`);
}


const productForm = document.getElementById('product-form') as HTMLFormElement;
const bookForm = document.getElementById('book-form') as HTMLFormElement;
const carForm = document.getElementById('car-form') as HTMLFormElement;
const employeeForm = document.getElementById('employee-form') as HTMLFormElement;
const courseForm = document.getElementById('course-form') as HTMLFormElement;

productForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const nameInput = document.getElementById('product-name') as HTMLInputElement;
  const priceInput = document.getElementById('product-price') as HTMLInputElement;
  const inStockInput = document.getElementById('product-in-stock') as HTMLInputElement;

  const name = nameInput.value;
  const price = parseFloat(priceInput.value);
  const inStock = inStockInput.checked;

  createAndDisplayProduct(name, price, inStock);
});

bookForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const titleInput = document.getElementById('book-title') as HTMLInputElement;
  const authorInput = document.getElementById('book-author') as HTMLInputElement;
  const pagesInput = document.getElementById('book-pages') as HTMLInputElement;
  const isAvailableInput = document.getElementById('book-is-available') as HTMLInputElement;

  const title = titleInput.value;
  const author = authorInput.value;
  const pages = parseInt(pagesInput.value);
  const isAvailable = isAvailableInput.checked;

  createAndDisplayBook(title, author, pages, isAvailable);
});

carForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const makeInput = document.getElementById('car-make') as HTMLInputElement;
  const modelInput = document.getElementById('car-model') as HTMLInputElement;
  const yearInput = document.getElementById('car-year') as HTMLInputElement;
  const isRunningInput = document.getElementById('car-is-running') as HTMLInputElement;

  const make = makeInput.value;
  const model = modelInput.value;
  const year = parseInt(yearInput.value);
  const isRunning = isRunningInput.checked;

  createAndDisplayCar(make, model, year, isRunning);
});

employeeForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const nameInput = document.getElementById('employee-name') as HTMLInputElement;
  const positionInput = document.getElementById('employee-position') as HTMLInputElement;
  const salaryInput = document.getElementById('employee-salary') as HTMLInputElement;
  const isFullTimeInput = document.getElementById('employee-is-full-time') as HTMLInputElement;

  const name = nameInput.value;
  const position = positionInput.value;
  const salary = parseFloat(salaryInput.value);
  const isFullTime = isFullTimeInput.checked;

  createAndDisplayEmployee(name, position, salary, isFullTime);
});

courseForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const titleInput = document.getElementById('course-title') as HTMLInputElement;
  const instructorInput = document.getElementById('course-instructor') as HTMLInputElement;
  const durationInput = document.getElementById('course-duration') as HTMLInputElement;
  const isOnlineInput = document.getElementById('course-is-online') as HTMLInputElement;

  const title = titleInput.value;
  const instructor = instructorInput.value;
  const duration = parseInt(durationInput.value);
  const isOnline = isOnlineInput.checked;

  createAndDisplayCourse(title, instructor, duration, isOnline);
});