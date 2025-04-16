import './style.css';
import {Product,processForm} from './formhandle';
import {Book,bookForm} from './formhandle';
import {Car,carForm} from './formhandle';
import {Employee,employeeForm} from './formhandle';
import {Course,courseForm} from './formhandle';



document.getElementById('productform')?.addEventListener('submit', (event) => {
  event.preventDefault();

  const textInputElement = document.getElementById('name') as HTMLInputElement;  
  const priceInputElement = document.getElementById('price') as HTMLInputElement;
  const instockInputElement = document.getElementById('instock') as HTMLInputElement;
  const product = new Product(textInputElement.value, parseFloat(priceInputElement.value), instockInputElement.checked);
  processForm(product); 
});

document.getElementById('bookform')?.addEventListener('submit', (event) => {
  event.preventDefault();
  
  const titleInputElement = document.getElementById('title') as HTMLInputElement;
  const authorInputElement = document.getElementById('author') as HTMLInputElement;
  const pagesInputElement = document.getElementById('pages') as HTMLInputElement;
  const isavailableInputElement = document.getElementById('isavailable') as HTMLInputElement;

  const book = new Book(titleInputElement.value, authorInputElement.value, parseInt(pagesInputElement.value), isavailableInputElement.checked);
  bookForm(book);
});

document.getElementById('carform')?.addEventListener('submit', (event) => {
  event.preventDefault();

  const makeInputElement = document.getElementById('make') as HTMLInputElement;
  const modelInputElement = document.getElementById('model') as HTMLInputElement;
  const yearInputElement = document.getElementById('year') as HTMLInputElement;

  const car = new Car(makeInputElement.value, modelInputElement.value, parseInt(yearInputElement.value));
  carForm(car);
});

document.getElementById('employeeform')?.addEventListener('submit', (event) => {
  event.preventDefault();

  const nameInputElement = document.getElementById('name') as HTMLInputElement;
  const positionInputElement = document.getElementById('position') as HTMLInputElement;
  const salaryInputElement = document.getElementById('salary') as HTMLInputElement;
  const isfulltimeInputElement = document.getElementById('isfulltime') as HTMLInputElement;

  const employee = new Employee(nameInputElement.value, positionInputElement.value, parseInt(salaryInputElement.value), isfulltimeInputElement.checked);
  employeeForm(employee);
});

document.getElementById('courseform')?.addEventListener('submit', (event) => {
  event.preventDefault();

  const nameInputElement = document.getElementById('name') as HTMLInputElement;
  const instructorInputElement = document.getElementById('instructor') as HTMLInputElement;
  const durationInputElement = document.getElementById('duration') as HTMLInputElement;
  const isonlineInputElement = document.getElementById('isonline') as HTMLInputElement;

  const course = new Course(nameInputElement.value, instructorInputElement.value, parseInt(durationInputElement.value), isonlineInputElement.checked);
  courseForm(course);
});
