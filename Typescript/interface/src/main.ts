interface Item {
  id: number;
  name: string;
}

interface Product extends Item {
  price: number;
  inStock: boolean;
}

interface Book extends Item {
  author: string;
  pages: number;
}

interface Car extends Item {
  make: string;
  model: string;
  year: number;
  isRunning: boolean;
}

interface Employee extends Item {
  position: string;
  salary: number;
  isFullTime: boolean;
}

interface Course extends Item {
  instructor: string;
  duration: number;
  isOnline: boolean;
}
class ProductImpl implements Product {
  id: number;
  name: string;
  price: number;
  inStock: boolean;

  constructor(id: number, name: string, price: number, inStock: boolean) {
    this.id = id;
    this.name = name;
    this.price = price;
    this.inStock = inStock;
  }
}

class BookImpl implements Book {
  id: number;
  name: string;
  author: string;
  pages: number;

  constructor(id: number, name: string, author: string, pages: number) {
    this.id = id;
    this.name = name;
    this.author = author;
    this.pages = pages;
  }
}

class CarImpl implements Car {
  id: number;
  name: string;
  make: string;
  model: string;
  year: number;
  isRunning: boolean;

  constructor(id: number, name: string, make: string, model: string, year: number, isRunning: boolean) {
    this.id = id;
    this.name = name;
    this.make = make;
    this.model = model;
    this.year = year;
    this.isRunning = isRunning;
  }
}

class EmployeeImpl implements Employee {
  id: number;
  name: string;
  position: string;
  salary: number;
  isFullTime: boolean;

  constructor(id: number, name: string, position: string, salary: number, isFullTime: boolean) {
    this.id = id;
    this.name = name;
    this.position = position;
    this.salary = salary;
    this.isFullTime = isFullTime;
  }
}

class CourseImpl implements Course {
  id: number;
  name: string;
  instructor: string;
  duration: number;
  isOnline: boolean;

  constructor(id: number, name: string, instructor: string, duration: number, isOnline: boolean) {
    this.id = id;
    this.name = name;
    this.instructor = instructor;
    this.duration = duration;
    this.isOnline = isOnline;
  }
}
const form = document.getElementById('form') as HTMLFormElement;
form.addEventListener('submit', (e) => {
  e.preventDefault();
  const formData = new FormData(form);

  // Product
  const productId = parseInt(formData.get('productId') as string);
  const productName = formData.get('productName') as string;
  const productPrice = parseFloat(formData.get('productPrice') as string);
  const productInStock = formData.get('productInStock') === 'true';
  const product = new ProductImpl(productId, productName, productPrice, productInStock);

  // Book
  const bookId = parseInt(formData.get('bookId') as string);
  const bookName = formData.get('bookName') as string;
  const bookAuthor = formData.get('bookAuthor') as string;
  const bookPages = parseInt(formData.get('bookPages') as string);
  const book = new BookImpl(bookId, bookName, bookAuthor, bookPages);

  // Car
  const carId = parseInt(formData.get('carId') as string);
  const carName = formData.get('carName') as string;
  const carMake = formData.get('carMake') as string;
  const carModel = formData.get('carModel') as string;
  const carYear = parseInt(formData.get('carYear') as string);
  const carIsRunning = formData.get('carIsRunning') === 'true';
  const car = new CarImpl(carId, carName, carMake, carModel, carYear, carIsRunning);

  // Employee
  const employeeId = parseInt(formData.get('employeeId') as string);
  const employeeName = formData.get('employeeName') as string;
  const employeePosition = formData.get('employeePosition') as string;
  const employeeSalary = parseFloat(formData.get('employeeSalary') as string);
  const employeeIsFullTime = formData.get('employeeIsFullTime') === 'true';
  const employee = new EmployeeImpl(employeeId, employeeName, employeePosition, employeeSalary, employeeIsFullTime);

  // Course
  const courseId = parseInt(formData.get('courseId') as string);
  const courseName = formData.get('courseName') as string;
  const courseInstructor = formData.get('courseInstructor') as string;
  const courseDuration = parseInt(formData.get('courseDuration') as string);
  const courseIsOnline = formData.get('courseIsOnline') === 'true';
  const course = new CourseImpl(courseId, courseName, courseInstructor, courseDuration, courseIsOnline);

  console.log('Product:', product);
  console.log('Book:', book);
  console.log('Car:', car);
  console.log('Employee:', employee);
  console.log('Course:', course);
});