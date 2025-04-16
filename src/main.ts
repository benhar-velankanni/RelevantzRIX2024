import { Product, processFormInput } from './formHandler';
import { Book, bookInput } from './formHandler';
import { Car, carInput } from './formHandler';
import { Employee, employeeInput } from './formHandler';
import { Course, courseInput } from './formHandler';
import './style.css'

document.getElementById('exampleForm')?.addEventListener('submit', function(event) { 
  event.preventDefault();

  const nameInputElement = document.getElementById('name') as HTMLInputElement;
  const priceInputElement = document.getElementById('price') as HTMLInputElement;
  const instockInputElement = document.getElementById('instock') as HTMLInputElement;

  
  const product = new Product(nameInputElement.value, Number(priceInputElement.value), instockInputElement.checked);
  processFormInput(product);
});

document.getElementById('bookForm')?.addEventListener('submit', function(event) {
  event.preventDefault();

  const titleInputElement = document.getElementById('title') as HTMLInputElement;
  const authorInputElement = document.getElementById('author') as HTMLInputElement;
  const pagesInputElement = document.getElementById('pages') as HTMLInputElement;
  const isAvailableInputElement = document.getElementById('isAvailable') as HTMLInputElement;

  const book = new Book(titleInputElement.value, authorInputElement.value, Number(pagesInputElement.value), isAvailableInputElement.checked);
  bookInput(book);
});

document.getElementById('carForm')?.addEventListener('submit', function(event) {
  event.preventDefault();

  const makeInputElement = document.getElementById('make') as HTMLInputElement;
  const modelInputElement = document.getElementById('model') as HTMLInputElement;  
  const yearInputElement = document.getElementById('year') as HTMLInputElement;
  const isAvailableInputElement = document.getElementById('isAvailable') as HTMLInputElement;

  const car = new Car(makeInputElement.value, modelInputElement.value, Number(yearInputElement.value), isAvailableInputElement.checked);
  carInput(car);
});

document.getElementById('employeeForm')?.addEventListener('submit', function(event) {
  event.preventDefault();

  const nameInputElement = document.getElementById('name') as HTMLInputElement;
  const positionInputElement = document.getElementById('position') as HTMLInputElement;
  const salaryInputElement = document.getElementById('salary') as HTMLInputElement;  
  const isAvailableInputElement = document.getElementById('isAvailable') as HTMLInputElement;

  const employee = new Employee(nameInputElement.value, positionInputElement.value, Number(salaryInputElement.value), isAvailableInputElement.checked);
  employeeInput(employee);
});

document.getElementById('courseForm')?.addEventListener('submit', function(event) {
  event.preventDefault();

  const titleInputElement = document.getElementById('title') as HTMLInputElement;
  const instructorInputElement = document.getElementById('instructor') as HTMLInputElement;
  const durationInputElement = document.getElementById('duration') as HTMLInputElement;  
  const isAvailableInputElement = document.getElementById('isAvailable') as HTMLInputElement;

  const course = new Course(titleInputElement.value, instructorInputElement.value, Number(durationInputElement.value), isAvailableInputElement.checked);
  courseInput(course);
});


